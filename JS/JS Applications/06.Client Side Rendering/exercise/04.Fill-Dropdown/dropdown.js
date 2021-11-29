import { render, html} from './node_modules/lit-html/lit-html.js'

const root = document.querySelector('div')
const form = document.querySelector('form').addEventListener('submit', addIthem)
const url = 'http://localhost:3030/jsonstore/advanced/dropdown'
const templait = (ithems) => html `<select id="menu">${ithems.map(ithem => html `<option value=${ithem._id}>${ithem.text}</option>`)}</select>`


getIthems()


function show(data){
    render(templait(data), root)
}


async function getIthems() {

    const response = await fetch(url)

    const data = await response.json()

    show(Object.values(data))
}


async function addIthem(event) {
    event.preventDefault()
    const text = document.getElementById('itemText').value
    
    const response = await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({ text })
    })

    if (response.ok == true) {
        getIthems()
    }
    event.target.reset()
}

