import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/api.js";
import {notify} from '../../src/notify.js';


const registerTamplate = (onSubmit) => html `
 <section id="register">
            <form id="register-form" @submit=${onSubmit}>
                <div class="container">
                    <h1>Register</h1>
                    <label for="username">Username</label>
                    <input id="username" type="text" placeholder="Enter Username" name="username">
                    <label for="email">Email</label>
                    <input id="email" type="text" placeholder="Enter Email" name="email">
                    <label for="password">Password</label>
                    <input id="password" type="password" placeholder="Enter Password" name="password">
                    <label for="repeatPass">Repeat Password</label>
                    <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
                    <div class="gender">
                        <input type="radio" name="gender" id="female" value="female">
                        <label for="female">Female</label>
                        <input type="radio" name="gender" id="male" value="male" checked>
                        <label for="male">Male</label>
                    </div>
                    <input type="submit" class="registerbtn button" value="Register">
                    <div class="container signin">
                        <p>Already have an account?<a href="/login">Sign in</a>.</p>
                    </div>
                </div>
            </form>
        </section>
`



export function registerPage(ctx) {
    ctx.render(registerTamplate(onSubmit))

    async function onSubmit(event) {
        event.preventDefault()

        const form = new FormData(event.target);

        const userName = form.get('username');
        const email = form.get('email');
        const paswsord = form.get('password');
        const repass = form.get('repeatPass')
        const gender = form.get('gender');

        if (userName == '' || email == '' || paswsord == '' || repass == '') {
           return notify('All fields are required');
        }

        if (paswsord != repass) {
            return notify('Passworda dont\'t match!');
        }

        await register(userName, email, paswsord, gender);
        ctx.updateNave();
        ctx.page.redirect('/memes')
    }

}