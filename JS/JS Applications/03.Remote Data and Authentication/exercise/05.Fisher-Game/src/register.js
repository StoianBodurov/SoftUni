window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', registerUser);
    const logoutButton = document.getElementById('user').style.display = 'none';


})


async function registerUser(e) {
    e.preventDefault();

   const formRegister = new FormData(e.target);

   const email = formRegister.get('email');
   const password = formRegister.get('password');
   const repass = formRegister.get('rePass');
   const url = 'http://localhost:3030/users/register'

   if (password != repass) {
       alert("Passwords don\'t match!");
       e.target.reset();
       return;
   }

   try {
       const response = await fetch(url, {
           method: 'post',
           headers: {
               'Content-Type': 'applicatin/json'
           },
           body: JSON.stringify({email, password})
       })

       if (response.ok != true) {
           const error = await response.json();
           throw new Error(error.message);
       }

       const data = await response.json();
       const userData = {
           email: data.email,
           id: data._id,
           token: data.accessToken
       }

       sessionStorage.setItem('userdata', JSON.stringify(userData))

       window.location = 'index.html'

   } catch(error) {
       alert(error.message);
   }
}