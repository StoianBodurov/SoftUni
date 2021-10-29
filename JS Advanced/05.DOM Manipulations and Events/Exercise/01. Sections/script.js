function create(words) {
   const container = document.getElementById('content')


   for (let word of words){
      const div = document.createElement('div')
      const p = document.createElement('p')
      p.style.display = 'none'

      p.textContent = word
      div.appendChild(p)
      container.appendChild(div)
}

   container.addEventListener('click', e => {e.target.childNodes[0].style.display = ''})


}