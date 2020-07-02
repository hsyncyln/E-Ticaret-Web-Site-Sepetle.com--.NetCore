"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/homewithuserHub").build();

document.getElementById("searchButton").disabled = true;

connection.start().then(function () {
    document.getElementById("searchButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("FixTheMyBasketArea", function (count) {

    let basketarea = document.getElementById("myBasketArea");
    basketarea.innerText = "Sepetim (" + count + ")";
});

function DeleteProduct(element) {

    var productId = element.value;
    var userId = document.getElementById("userId").value;

    console.log(element.parentNode.parentNode.parentNode);
    element.parentNode.parentNode.parentNode.style["display"] = "none";

    connection.invoke("DeleteProduct", productId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

function RemoveBasket(element) {

    var productId = element.value;
    var userId = document.getElementById("myBasketUserId").value;

    element.style["backgroundColor"] = "#0069d9";
    element.innerText = "Sepete Ekle";
    element.onclick = function () { AddBasket(this); };
    

    connection.invoke("RemoveProduct", productId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

function AddBasket(element) {

    var productId = element.value;
    var userId = document.getElementById("myBasketUserId").value;

    element.style["backgroundColor"] = "red";
    element.innerText = "Sepetten Çıkar";
    element.onclick = function () { RemoveBasket(this); };
   
    connection.invoke("AddProduct", productId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}


connection.on("NewContainer", function () {

    let container = document.getElementById("container");
    container.remove();

    let newcontainer = document.createElement("div");
    newcontainer.id = "container";

    let body = document.getElementById("fixedbody");
    body.appendChild(newcontainer);


});

connection.on("ReceiveSearch", function (id, price, name, picture, category) {

    let container = document.getElementById("container");

    let card = document.createElement("div");
    card.classList.add("card");
    card.style.cssText = "width: 18rem;margin:1%;display:inline-block;";

    let img = document.createElement("img");
    img.classList.add("card-img-top");
    img.src = picture;
    img.width = 100;
    img.height = 180;

    card.appendChild(img);

    let cardbody = document.createElement("div");
    cardbody.classList.add("card-body");

    let cardpname = document.createElement("h5");
    cardpname.classList.add("card-title");
    cardpname.innerText = name;

    cardbody.appendChild(cardpname);

    let cardcname = document.createElement("p");
    cardcname.classList.add("card-text");
    cardcname.innerText = category;

    cardbody.appendChild(cardcname);

    let cardprice = document.createElement("p");
    cardprice.classList.add("card-text");
    cardprice.innerText = price + " $";

    cardbody.appendChild(cardprice);

    let button = document.createElement("button");
    button.classList.add("btn");
    button.classList.add("btn-primary");
    button.onclick = "AddBasket(this)";
    button.value = id;
    button.innerText = "Sepete Ekle";

    cardbody.appendChild(button);

    card.appendChild(cardbody);

    container.appendChild(card);


});


document.getElementById("searchButton").addEventListener("click", function (event) {
    var value = document.getElementById("searchBox").value;

    connection.invoke("GetSearch", value).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function SearchItem(value) {

    connection.invoke("SearchItem", value).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}