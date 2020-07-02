"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/myBasket").build();


document.getElementById("btnBuy").disabled = true;

connection.start().then(function () {
    document.getElementById("btnBuy").disabled = false;

}).catch(function (err) {
    return console.error(err.toString());
});


connection.on("NewContainer", function () {

    let container = document.getElementById("container");
    container.remove();

    let newcontainer = document.createElement("div");
    newcontainer.id = "container";

    let body = document.getElementById("fixedbody");
    body.appendChild(newcontainer);


});

connection.on("BuySuccess", function () {

});



function RemoveBasket(element) {

    var productId = element.value;
    var userId = document.getElementById("userId").value;

    console.log(element.parentNode.parentNode.parentNode);
    element.parentNode.parentNode.parentNode.style["display"] = "none";

    connection.invoke("RemoveProduct", productId, userId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

connection.on("FixTheMyBasketArea", function (count) {

    let basketarea = document.getElementById("myBasketArea");
    basketarea.innerText = "Sepetim (" + count + ")";
});