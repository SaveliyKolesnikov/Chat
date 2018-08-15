class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
const whenInput = document.getElementById('when');
const chat = document.getElementById('chat');

document.getElementById('submitButton').addEventListener('click', () =>
    whenInput.value = new Date().format("m/dd/yyyy hh:MM TT")
);

function sendMessage() {
    let text = textInput.value;
    if (text.trim() === "") return;

    let when = new Date();
    let message = new Message(username, text, when);
    sendMessageToHub(message);
    textInput.value = "";
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.userName === username;

    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.userName;

    let text = document.createElement('p');
    text.innerHTML = message.text;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-left" : "time-right";
    when.innerHTML = new Date(message.when).format("m/dd/yyyy hh:MM TT");

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
}
