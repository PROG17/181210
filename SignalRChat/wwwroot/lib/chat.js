"use strict";

// Skapa och konfigurera Connection
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub").build();

// Skapa event handlers för att ta emot meddelandet
connection.on("ReceiveMessage", (user, message) => {
    var element = document.createElement("li");
    element.textContent = `${user} says ${message}`;
    document.getElementById("messageList").appendChild(element);
});

// Ansluta till server
connection.start().catch(err => {
    return console.error(err.toString());
});

// Koppla upp skicka knappen
document.getElementById("sendButton").addEventListener("click", e => {
    e.preventDefault();

    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message).catch(err => {
        return console.error(err.toString());
    });

});

