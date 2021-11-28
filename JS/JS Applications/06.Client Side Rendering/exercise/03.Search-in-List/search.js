import {html, render} from './node_modules/lit-html/lit-html.js'
import {towns as data} from './towns.js'


const list = document.getElementById('towns');
const towns = data.map(t => ({name: t, matches: false}))
const button = document.querySelector('button').addEventListener('click', onClick)

const townsList = (towns) => html `<ul>${towns.map(town => html `<li class=${town.matches ? 'active' : ''}>${town.name}</li>`)}</ul>`;


function update(){
   render(townsList(towns), list)

}

update()

function onClick() {
   const search = document.getElementById('searchText');
   const searchValue = search.value.trim().toLocaleLowerCase();
   const result = document.getElementById('result')
   result.replaceChildren()
   const p = document.createElement('p')
   let countOfMatches = 0;

   for (let town of towns) {
      if (searchValue && town.name.toLocaleLowerCase().includes(searchValue)){
         town.matches = true
         countOfMatches++
      } else {
         town.matches = false
      }
   }
   search.value = ''
   p.textContent = `${countOfMatches} matches found`
   result.appendChild(p)

   update()
}


