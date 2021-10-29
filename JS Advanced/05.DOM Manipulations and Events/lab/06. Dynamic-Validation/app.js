function validate() {
    const input = document.getElementById('email');
    input.addEventListener('change', validate)

    function validate(event) {
        const pattern = /^[a-z]+@[a-z]+\.[a-z]+$/

        if (pattern.test(event.target.value)){
            event.target.classList.remove('error')
        } else {
            event.target.classList.add('error')
        }
    }
}