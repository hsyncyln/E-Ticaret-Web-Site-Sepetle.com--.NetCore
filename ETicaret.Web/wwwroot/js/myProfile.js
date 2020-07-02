"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/homewithuserHub").build();

connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});


document.getElementById("btnUpdate").addEventListener("click", function (event) {
    var country = document.getElementById("country").value;
    var city = document.getElementById("city").value;
    var district = document.getElementById("district").value;
    var street = document.getElementById("street").value;
    var door = document.getElementById("door").value;
    var addressid = document.getElementById("addressid").value;
    var userid = document.getElementById("btnUpdate").value;

    connection.invoke("AddressUpdate", addressid, country, city, district, street, door, userid).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("InputSuccess", function () {

    let place = document.getElementById("addaddress-place");
    place.style["backgroundColor"] = "green";
});

