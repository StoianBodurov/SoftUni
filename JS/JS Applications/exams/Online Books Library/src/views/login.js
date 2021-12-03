import {html} from '../../node_modules/lit-html/lit-html.js';
import { login } from '../api/api.js';


const loginTemplate = (onSubmit) => html `
     <section id="login-page" class="login">
            <form id="login-form" @submit=${onSubmit}>
                <fieldset>
                    <legend>Login Form</legend>
                    <p class="field">
                        <label for="email">Email</label>
                        <span class="input">
                            <input type="text" name="email" id="email" placeholder="Email">
                        </span>
                    </p>
                    <p class="field">
                        <label for="password">Password</label>
                        <span class="input">
                            <input type="password" name="password" id="password" placeholder="Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Login">
                </fieldset>
            </form>
        </section>
`


export function loginPage(ctx) {
    ctx.render(loginTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault()

        const loginForm = new FormData(event.target);

        const email = loginForm.get('email').trim();
        const password = loginForm.get('password').trim();

        if (email == '' || password == ''){

            return alert('All fields are require');
        }

        await login(email, password)
        ctx.updateNav()
        ctx.page.redirect('/')
    }

}