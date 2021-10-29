function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');
    const selectMenu = document.getElementById('menu');

    const selectOption = document.createElement('option');
    selectOption.textContent = inputText.value;
    selectOption.value = inputValue.value
    selectMenu.appendChild(selectOption);
    
    inputText.value = '';
    inputValue.value = '';

}