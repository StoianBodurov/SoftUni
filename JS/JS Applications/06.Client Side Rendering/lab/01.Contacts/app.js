import { render, html } from "./node_modules/lit-html/lit-html.js";
import {contacts as data} from './contacts.js'

const contacts = document.getElementById('contacts');

const contactCard = (contact) => html`<div class="contact card">
            <div>
                <i class="far fa-user-circle gravatar"></i>
            </div>
            <div class="info">
                <h2>Name: ${contact.name}</h2>
                <button class="detailsBtn" @click=${onClick}>Details</button>
                <div class="details" id="${contact.id}">
                    <p>Phone number: ${contact.phoneNumber}</p>
                    <p>Email: ${contact.email}</p>
                </div>
            </div>
        </div>`   
        
        
render(data.map(c  => contactCard(c)), contacts)

function onClick(e) {

    const details = e.target.parentNode.querySelector('.details')

    if (details.style.display == '') {
        details.style.display = 'block'
    } else {
        details.style.display = ''
    }
}