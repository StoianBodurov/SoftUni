window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', loginUser);
    const logoutButton = document.getElementById('user').style.display = 'none';


})



async function loginUser(e) {
    e.preventDefault()

    const url = 'http://localhost:3030/users/login'
    const loginForm = new FormData(e.target);

    const email = loginForm.get('email');
    const password = loginForm.get('password');
    try {
        const response = await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email, password})
    
        })
    
        if (response.ok != true) {
            const error = await response.json()
            throw new Error(error.message);
        }

        const data = await response.json();

        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToken
        }

        sessionStorage.setItem('userdata', JSON.stringify(userData));
        window.location = 'index.html';

    } catch(error) {
        alert(error.message)
    }


}