import {render} from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { logout } from './api/api.js';
import { loginPage } from './views/login.js';
import { registertPage } from './views/register.js';
import {getUserData} from './utils.js'
import { createPage } from './views/create.js';
import { dashbordPage } from './views/dashbord.js';
import { detaildPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { myBookPage } from './views/mybook.js';



const root = document.getElementById('site-content')
document.getElementById('logoutBtn').addEventListener('click', onLogout)


page(decorateContext)
page('/login', loginPage)
page('/register', registertPage)
page('/create', createPage)
page('/', dashbordPage)
page('/details/:id', detaildPage)
page('/edit/:id', editPage)
page('/mybook', myBookPage)

updateNav()
page.start()


function decorateContext(ctx, next) {
    ctx.render = (context) => render(context, root)
    ctx.updateNav = updateNav

    next()
}


function onLogout() {
    logout()
    updateNav()
    page.redirect('/')

}

function updateNav() {
    const userData = getUserData()

    if (userData) {
        console.log(document.querySelector('.user span'))
        document.getElementById('user').style.display = 'block'
        document.getElementById('guest').style.display = 'none'
        document.querySelector('#user span').textContent = `Welcome, ${userData.email}`
    } else {
        document.getElementById('user').style.display = 'none'
        document.getElementById('guest').style.display = 'block'

    }

}