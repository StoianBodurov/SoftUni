function attachEvents() {

   const author = document.querySelector('[name=author] ');
   const message = document.querySelector('[name=content]');
   

   const submitButton = document.getElementById('submit').addEventListener('click', sendMessage);
   const refreshButton = document.getElementById('refresh').addEventListener('click', refresh);
   
}

attachEvents()

async function refresh() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const textArea = document.getElementById('messages');
    const result = [];

    const response = await fetch(url);
    const data = await response.json();

    const messages = Object.values(data);
    for (let message of messages) {
        result.push(`${message.author}: ${message.content}`);
    }
    textArea.textContent = result.join('\n');


}


function sendMessage() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const author = document.querySelector('[name=author] ');
    const message = document.querySelector('[name=content]');

    const data = {author: author.value, content: message.value}

    if (author.value != '' && message.value != '') {
        fetch(url, {
            method: 'post',
            headers: {'Content-type': 'application/json'},
            body: JSON.stringify(data)
        })
        
    }


    message.value = ''



}