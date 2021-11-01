function addItem() {
    const inputValue = document.getElementById('newItemText').value;


    let li = document.createElement('li');
    li.textContent = inputValue;

    let a = document.createElement('a');
    let link = document.createTextNode('[Delete]');

    a.appendChild(link);
    a.href = '#';
    a.addEventListener('click', ()  => li.remove());

    li.appendChild(a);
    document.getElementById('items').appendChild(li);

}