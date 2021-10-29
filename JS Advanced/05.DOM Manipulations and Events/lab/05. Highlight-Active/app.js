function focused() {
    const inputs = Array.from(document.getElementsByTagName('input'));

    for (let input of inputs) {
        input.addEventListener('focus', e =>{e.target.parentNode.className = 'focused'})
        input.addEventListener('blur', e => {e.target.parentNode.className = ''})
    }
 }