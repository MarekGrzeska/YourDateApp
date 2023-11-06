const chatBody = document.querySelector(".chat-body");
const msgInput = document.querySelector("#chatInput");
const sendBtn = document.querySelector("#sendBtn");
const closeBtn = document.querySelector(".closeChatBtn");
const chatContainer = document.querySelector(".chat-container");
const chatTitle = document.querySelector("#chatTitle");

let chatCurrentUsername = "";
let chatUsernameWith = "";

const startChat = (usernameFrom, usernameTo) => {
    chatCurrentUsername = usernameFrom;
    chatUsernameWith = usernameTo;
    chatTitle.innerHTML = `Chat z ${chatUsernameWith}`;
    chatContainer.setAttribute("style", "display: ");
    getAllMessageFromApi();
}

closeBtn.addEventListener("click", () => {
    chatBody.replaceChildren();
    chatContainer.setAttribute("style", "display: none")
})

sendBtn.addEventListener("click", () => {
    sendMessageToApi();
})

msgInput.addEventListener("keyup", (event) => {
    if (event.keyCode === 13) {
        sendMessageToApi();
    }
})

const sendMessageToApi = () => {
    const content = msgInput.value;
    const url = `/Interaction/SendMessage`;
    const msg = {
        Content: content,
        UsernameFrom: chatCurrentUsername,
        UsernameTo: chatUsernameWith
    }

    $.ajax({
        url: url,
        type: 'post',
        data: msg,
        dataType: "json",
    })
    renderMessage("");
}

const getAllMessageFromApi = () => {
    const url = '/Interaction/GetAllMessage'
    const getMsg = {
        UsernameFrom: chatCurrentUsername,
        UsernameTo: chatUsernameWith
    }
    $.ajax({
        url: url,
        type: 'get',
        data: getMsg,
        dataType: "json",
        success: (data) => {
            addMessagesToChat(data);
        }
    })
}

const addMessagesToChat = (messages) => {
    if (messages === null || messages.lenght === 0) {
        return;
    }
    messages.forEach(msg => {
        let msgType = msg.usernameFrom === chatCurrentUsername ? "" : "2";
        renderMessageElement(msg.content, msgType, msg.sentDate)
    });
    setScrollPosition();
}

const renderMessage = (type) => {
    const userInput = msgInput.value;
    if (isEmptyOrSpaces(userInput)) {
        msgInput.value = "";
        return;
    }
    renderMessageElement(userInput, type, null);
    msgInput.value = "";
    setScrollPosition();

}

const renderMessageElement = (msg, type, msgDate = null) => {
    const dateElement = document.createElement("div");
    const date = msgDate === null ? new Date() :  new Date(Date.parse(msgDate));
    const currentDate = date.toLocaleTimeString() + ' ' + date.toLocaleDateString();
    const dateNode = document.createTextNode(currentDate);
 

    dateElement.classList.add("user-message-date" + type);
    dateElement.append(dateNode);
    chatBody.append(dateElement);

    const msgElement = document.createElement("div");
    const txtNode = document.createTextNode(msg);
    msgElement.classList.add("user-message" + type);
    msgElement.append(txtNode);
    chatBody.append(msgElement);
}

const setScrollPosition = () => {
    if (chatBody.scrollHeight > 0) {
        chatBody.scrollTop = chatBody.scrollHeight;
    }
}

const isEmptyOrSpaces = (str) => { 
    return str === null || str.match(/^ *$/) !== null;
}
