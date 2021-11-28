import {html, render} from './node_modules/lit-html/lit-html.js'
import {cats} from './catSeeder.js'

const section = document.getElementById('allCats');


const catCard = (cats) => html `<ul>${cats.map(cat => html`<li>
                <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
                <div class="info">
                    <button class="showBtn" @click=${onClick}>Show status code</button>
                    <div class="status" style="display: none" id="${cat.id}">
                        <h4>Status Code: ${cat.statusCode}</h4>
                        <p>Continue</p>
                    </div>
                </div>
            </li>`)}</ul>`

render(catCard(cats), section)


function onClick(e) {
    const button = e.target;
    const hidenDiv = button.parentNode.querySelector('div');
    if (hidenDiv.style.display == 'none'){
        hidenDiv.style.display = 'block'
        button.textContent = 'Hide status code'
    }else {
        hidenDiv.style.display = 'none'
        button.textContent = 'Show status code'

    }

}