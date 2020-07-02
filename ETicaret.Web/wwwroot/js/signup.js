"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signupHub").build();

document.getElementById("btnSignUp").disabled = true;


connection.start().then(function () {
    document.getElementById("btnSignUp").disabled = false;

}).catch(function (err) {
    return console.error(err.toString()); 
});

connection.on("RequestControl", function (control) {

    console.log(control);
    if (control == true) {
        var signup = document.getElementById("signup-place");
        signup.style["backgroundColor"] = "green";
        //success
    }
    else {
        var signup = document.getElementById("signup-place");
        signup.style["backgroundColor"] = "purple";
        //failed
    }
});


document.getElementById("btnSignUp").addEventListener("click", function () {
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var email = document.getElementById("signup-email").value;
    var password = document.getElementById("signup-password").value;
    var tel = document.getElementById("signup-tel").value;

    connection.invoke("UserAdd", fname,lname,email,password,tel).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});