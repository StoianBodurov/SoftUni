function search() {
   const list = document.querySelectorAll('li');
   const search = document.getElementById('searchText').value;
   const result = document.getElementById('result')
   let count = 0;
   
   if (search) {
      for (el of list) {
         let text = el.textContent;
         if (text.includes(search)) {
            count += 1
            el.style.fontWeight = 'bold'
            el.style.textDecoration = 'underline'

            console.log(el.textContent)
         } else {
            el.style.fontWeight = ''
            el.style.textDecoration = ''
         }
      }
   }
   result.textContent = `${count} matches found`
}
