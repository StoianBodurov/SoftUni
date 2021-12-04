import { html } from '../../node_modules/lit-html/lit-html.js'
import { register } from '../api/api.js';


const registerTemplate = (onSubmit) => html `
    <section id="registerPage">
            <form @submit=${onSubmit}>
                <fieldset>
                    <legend>Register</legend>

                    <label for="email" class="vhide">Email</label>
                    <input id="email" class="email" name="email" type="text" placeholder="Email">

                    <label for="password" class="vhide">Password</label>
                    <input id="password" class="password" name="password" type="password" placeholder="Password">

                    <label for="conf-pass" class="vhide">Confirm Password:</label>
                    <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

                    <button type="submit" class="register">Register</button>

                    <p class="field">
                        <span>If you already have profile click <a href="#">here</a></span>
                    </p>
                </fieldset>
            </form>
        </section>
`


export function registerPage(ctx) {
    ctx.render(registerTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault() 

        const form = new FormData(event.target)

        const email = form.get('email');
        const password = form.get('password')
        const repass = form.get('conf-pass')

        if (email == '' || password == '' || repass == ''){
            return alert('Allfields are required')
        }

        if (password != repass) {
            return alert('Passord don\'t matc')
        }

        await register(email, password)
        ctx.updateNav()
        ctx.page.redirect('/')
    }



}