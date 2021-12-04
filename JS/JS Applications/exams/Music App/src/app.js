import {render} from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { getUserData } from './utils.js'
import { loginPage} from './views/login.js'
import { logout} from './api/api.js'
import { registerPage } from './views/register.js';
import { catalogPage } from './views/catalog.js';
import { homePage } from './views/home.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { searchPage } from './views/search.js';



const root = document.getElementById('main-content')
document.getElementById('logout').addEventListener('click', onDelete)


page(decorateContext)
page('/login', loginPage)
page('/register', registerPage)
page('/catalog', catalogPage)
page('/', homePage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/search', searchPage)



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
        document.getElementById('login').style.display = 'none'
        document.getElementById('register').style.display = 'none'
        document.getElementById('createalbum').style.display = 'inline-block'
        document.getElementById('logout').style.display = 'inline-block'

    } else {
        document.getElementById('login').style.display = 'inline-block'
        document.getElementById('register').style.display = 'inline-block'
        document.getElementById('createalbum').style.display = 'none'
        document.getElementById('logout').style.display = 'none'

    }
}
