function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rows = document.querySelectorAll('tbody tr')
      const searchField = document.getElementById('searchField')
   
     
         for (let r of rows) {
            r.className = '';
      
            if (r.textContent.toLowerCase().includes(searchField.value.toLowerCase())){
               r.className = 'select';
                           
            }
         }
         
         searchField.value = '';
      }
}

