
class Message {
    constructor(username, text, when) {
        this.username = username;
        this.text = text;
        this.when = when;
    }
}

const messagesQueue = [];
const username = usrName;
const textInput = document.getElementById('messageText');
const chat = document.getElementById('chat');

function sendMessage() {
    // 8/14/2018
    let when = new Date().format("m/dd/yyyy h:MM TT");
    let message = new Message(username, textInput.value, when);
    messagesQueue.push(message);
}

function messageHasBeenSent() {
    addMessageToChat(messagesQueue.shift())
}

function addMessageToChat(message) {
    let container = document.createElement('div');
    container.className = "container darker";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.username;

    let text = document.createElement('p');
    text.innerHTML = message.text;

    let when = document.createElement('span');
    when.className = "time-left";
    when.innerHTML = message.when.toString("");

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
    textInput.value = "";
}
