import {html, render} from './node_modules/lit-html/lit-html.js'

const list = document.getElementById('root');
// const data = ['sofia', 'plovdiv', 'varna'];

const ulElement = (data) => html `<ul>${data.map(d => html`<li>${d}</li>`)}</ul>`;
document.querySelector('form').addEventListener('submit', onSubmit );

function onSubmit(e) {
    e.preventDefault()
    const input = document.getElementById('towns')

    if (input.value != '') {
        const data = input.value.split(', ');
    
        render(ulElement(data), list)
        input.value = ''

    }

}