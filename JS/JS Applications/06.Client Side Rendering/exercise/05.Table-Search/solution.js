import { html, render } from './node_modules/lit-html/lit-html.js';

const root = document.querySelector('tbody');
const searchInput = document.getElementById('searchField');


const rowTemplate = (student, select) => html `
   <tr class=${select ? 'select' : ''}>
      <td>${student.firstName} ${student.lastName}</td>
      <td>${student.email}</td>
      <td>${student.course}</td>
   </tr>`;

start();

async function start() {
   document.getElementById('searchBtn').addEventListener('click', (e) => update(result))

   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
  
   const result = Object.values(data);

   update(result);
   
}

function update(items, match = '') {
   const inputValue = searchInput.value;
   const result = items.map(e => rowTemplate(e, compare(e, inputValue)));


   render(result, root );
   searchInput.values = '';

}

function compare(item, match) {
   return Object.values(item).some(e => match && e.toLocaleLowerCase().includes(match.toLocaleLowerCase()));
}




