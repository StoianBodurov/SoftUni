import {render} from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs'
import { logout } from './api/api.js';
import { getUserData } from './utils.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';

import {homePage} from './views/home.js'
import { loginPage } from './views/login.js';
import { memesPage } from './views/memes.js';
import { profilePage } from './views/profile.js';
import { registerPage } from './views/register.js';


const root = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout)


page(decoratorContext);
page('/', homePage)
page('/memes', memesPage)
page('/login', loginPage)
page('/register', registerPage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/profile', profilePage)
updateNave()
page.start()








function decoratorContext(ctx, next) {
    ctx.render = (content) => render(content , root)
    ctx.updateNave = updateNave

    next()
}

function onLogout(){
    logout()
    updateNave()
    page.redirect('/')
}


function updateNave() {
    const userData = getUserData();

    if (userData) {
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.user span').textContent = `Welcom, ${userData.email}`

    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'block';
    }
}







