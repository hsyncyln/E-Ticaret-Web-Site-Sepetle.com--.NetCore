using System;
using ETicaret.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETicaret.Common.DTO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Stripe;
using BillModel = ETicaret.Web.Models.BillModel;

namespace ETicaret.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            MainModel model = new MainModel();
            model.Products = GetApiResult<IEnumerable<ProductModel>>("/product/getall");
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignIn(string email, string password)
        {

            int userid = GetApiResult<int>("/user/getid/"+email+"&"+password);

            if (userid != 0)
            {
                HttpContext.Session.SetInt32("id", userid);
                return RedirectToAction("HomePageWithUser");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult HomePageWithUser()
        {          

            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");
                
                MainModel model = new MainModel();

                model.User = GetApiResult<UserModel>("/user/get/"+ userid);

                model.Basket = GetApiResult<IEnumerable<ProductModel>>("/basket/getproducts/" + userid);

                model.Products = GetApiResult<IEnumerable<ProductModel>>("/product/getall");

                return View(model);
            }

        }

        public IActionResult MyBasket()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");

                BasketModel model = new BasketModel();

                model.User = GetApiResult<UserModel>("/user/get/" + userid);

                model.Basket = GetApiResult<IEnumerable<ProductModel>>("/basket/getproducts/" + userid);

                return View(model);
            }
        }
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");          

                ProfileModel model = new ProfileModel();

                model.User = GetApiResult<UserModel>("/user/get/" + userid);

                model.Basket = GetApiResult<IEnumerable<ProductModel>>("/basket/getproducts/" + userid);

                model.Address = GetApiResult<AddressModel>("/address/getaddress/" + userid);

                model.SupplyProducts = GetApiResult<IEnumerable<ProductModel>>("/product/myproducts/" + userid);

                try
                {
                    model.BoughtProducts = GetApiResult<IEnumerable<ProductModel>>("/bill/get/" + userid);                       
                }
                catch {  }

                return View(model);
            }

        }
        public IActionResult BeSupplier()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");

                BeSupplierModel model = new BeSupplierModel();

                model.User = GetApiResult<UserModel>("/user/get/" + userid);

                model.Basket = GetApiResult<IEnumerable<ProductModel>>("/basket/getproducts/" + userid);

                return View(model);
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index");
        }
        public IActionResult AddProduct(string pdbimage, string pname, string category, int pquentity, double pprice)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");
                var product = new JObject();
                product.Add("ProductName", pname);
                product.Add("CategoryName", category);
                product.Add("Price", pprice);
                product.Add("StockQuentity", pquentity);
                product.Add("ProductPicture", pdbimage);
                product.Add("Id", Convert.ToInt32(userid));

                bool control = PostApiResult<JObject>("/product/addproduct", product);

                if (control == true)
                {
                    return RedirectToAction("HomePageWithUser");
                }
                else
                {
                    return RedirectToAction("BeSupplier", userid);
                }
            }
        }

        public IActionResult Bill(string list)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if(list != "" && list !=null)
                {
                    ViewBag.list = list;
                    List<ProductModel> products = new List<ProductModel>();

                    while (list.Contains("-"))
                    {
                        string value = list.Substring(0, list.IndexOf("-"));
                        products.Add(GetApiResult<ProductModel>("/product/get/" + value));
                        list = list.Substring(list.IndexOf("-") + 1);
                    }

                    int userid = (int)HttpContext.Session.GetInt32("id");

                    BillModel model = new BillModel();

                    model.User = GetApiResult<UserModel>("/user/get/" + userid);

                    model.Basket = GetApiResult<IEnumerable<ProductModel>>("/basket/getproducts/" + userid);

                    model.Address = GetApiResult<AddressModel>("/address/getaddress/" + userid);

                    model.Products = products;

                    return View(model);
                }
                else return RedirectToAction("MyBasket");

            }

        }
        public IActionResult Payment(string totalamount,string list)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                int userid = (int)HttpContext.Session.GetInt32("id");

                PaymentModel model = new PaymentModel();
                model.Amount = Convert.ToInt32(totalamount);
                model.Email = GetApiResult<UserModel>("/user/get/" + userid).EMail;
                ViewBag.list = list;
                return View(model);
            }
        }

        [HttpPost]   
        public IActionResult Charge(string Token,string Amount,string Email,string list)
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = Email,
                Source= Token
            };
            var customerService = new CustomerService();
            Customer customer = customerService.Create(customerOptions);

            var chargeOptions = new ChargeCreateOptions
            {
                Customer = customer.Id,
                Amount = Convert.ToInt32(Amount)*100,
                Currency = "usd",
            };
            var chargeService = new ChargeService();
            Charge charge = chargeService.Create(chargeOptions);

            if(charge.Status == "succeeded")
            {
                int userid = (int)HttpContext.Session.GetInt32("id");

                AddressModel address= GetApiResult<AddressModel>("/address/getaddress/" + userid);

              
                while (list.Contains("-"))
                {
                    try { 

                        string value = list.Substring(0, list.IndexOf("-"));

                        var bill = new JObject();
                        bill.Add("UserId", userid);
                        bill.Add("ProductId", value);
                        bill.Add("Address", address.FullAddress);
                        bill.Add("Price", GetApiResult<ProductModel>("/product/get/" + value).Price);
                        bill.Add("Quentity", 1);

                        bool control = PostApiResult<JObject>("/bill/addbill", bill);
                        bool ctr = GetApiResult<bool>("/basket/removeproduct/" + value + "&" + userid);
                        list = list.Substring(list.IndexOf("-") + 1);
                    }
                    catch
                    {
                        continue;
                    }
                    
                }
             
                return RedirectToAction("MyBasket");
            }
            else {
                
                return RedirectToAction("HomePageWithUser");
            }
        }

    }
}
