import {html} from '../../node_modules/lit-html/lit-html.js';
import { login } from '../api/api.js';



const loginTemplate = (onsubmit) => html `
 <section id="login-page" class="auth">
    <form id="login" @submit=${onsubmit}>

        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
    </form>
</section>
`

export function loginPage(ctx) {
    ctx.render(loginTemplate(onsubmit))


    async function onsubmit(event) {
        event.preventDefault()

        const form = new FormData(event.target)

        const email = form.get('email');
        const password = form.get('password')

        if (email == '' || password == '') {
            return alert('All fields are required')
        }

        await login(email, password)
        ctx.updateNav()
        ctx.page.redirect('/')
    }



}