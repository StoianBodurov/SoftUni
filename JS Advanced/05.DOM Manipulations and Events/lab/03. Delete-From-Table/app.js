function deleteByEmail() {
    const table = document.querySelectorAll('table td');
    const input = document.getElementsByName('email')[0].value;
    const result = document.getElementById('result');
    let error = true;

    for (let el of table) {
        if (el.textContent == input) {

            el.parentElement.remove();
            error = false;

        } 
    }

    if (error) {
        result.textContent = 'Not found.'

    } else {
        result.textContent = 'Deleted.'
    }

    
}