"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/index").build();

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});


connection.on("NewContainer", function () {

    let container = document.getElementById("container");
    container.remove();

    let newcontainer = document.createElement("div");
    newcontainer.id = "container";
    newcontainer.style.cssText += "padding-top:12%;"

    let body = document.getElementById("here");
    body.appendChild(newcontainer);


});

connection.on("ReceiveSearch", function (id, price, name, picture, category) {

    

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
    button.value = id;
    button.innerText = "Sepete Ekle";

    cardbody.appendChild(button);

    card.appendChild(cardbody);

    let container = document.getElementById("container");
    
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