import {html} from '../../node_modules/lit-html/lit-html.js';
import { register } from '../api/api.js';


const registerTemplate = (onSubmit) => html `
        <section id="register-page" class="register">
            <form id="register-form" @submit=${onSubmit}>
                <fieldset>
                    <legend>Register Form</legend>
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
                    <p class="field">
                        <label for="repeat-pass">Repeat Password</label>
                        <span class="input">
                            <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Register">
                </fieldset>
            </form>
        </section>

`


export function registertPage(ctx) {
    ctx.render(registerTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault()

        const registerForm = new FormData(event.target);

        const email = registerForm.get('email').trim();
        const password = registerForm.get('password').trim();
        const repass = registerForm.get('confirm-pass').trim();


        if (email == '' || password == ''){

            return alert('All fields are require');
        }

        if (password != repass) {
            return alert('Passord don\'t match')
        }

        await register(email, password)
        ctx.updaeNav()
        ctx.page.redirect('/')
    }

}