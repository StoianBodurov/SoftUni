import {render} from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs'
import { logout } from './api/api.js';
import { getUserData } from './utils.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';


const root = document.getElementById('main-content');
document.getElementById('logoutBtn').addEventListener('click', onDelete)


page(decorateContext);
page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page.start()

updateNav()

function decorateContext(ctx, next) {
    ctx.render = (context) => render(context, root)
    ctx.updateNav = updateNav

    next()
}

function onDelete() {
    logout()
    updateNav()
    page.redirect('/')
}

export function updateNav(){
    const userData = getUserData()

    if (userData) {
        document.getElementById('guest').style.display = 'none'
        document.getElementById('user').style.display = 'block'

    } else {
        document.getElementById('guest').style.display = 'block'
        document.getElementById('user').style.display = 'none'

    }
}