
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


document.getElementById('btn').disabled = true;

connection.on("ReceiveMessage", (user, message) => {
    let encondeMsg = user + " say " + message;
    let li = document.createElement("li");
    li.textContent = encondeMsg;
    document.getElementById('messageList').appendChild(li);
});


connection.start().then(() => {
    document.getElementById('btn').disabled = false;
}).catch((e) => console.log(e));


document.getElementById("btn").addEventListener("click", (event) => {
    let user = document.getElementById("name").value;
    let message = document.getElementById("message").value;
    connection.invoke("SendMessage", user, message).catch((err) => {
        return console.error(err.toString());
    });
    event.preventDefault();
});

