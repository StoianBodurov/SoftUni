function validate() {
    const inputField = document.getElementById('email');
    const validator = /(^[a-z]+@[a-z]+\.[a-z]+$)/;
    inputField.addEventListener('change', e => validateEmail());


    function validateEmail(){
        if (!validator.test(inputField.value)){
            inputField.classList.add('error');
        } else {
            inputField.classList.remove('error');
        };

    };
}