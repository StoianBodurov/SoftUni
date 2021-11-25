const loadButton = document.getElementById('loadBooks')
loadButton.addEventListener('click', getBooks)
const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

const h3 = form.querySelector('h3');
const submitButton = form.querySelector('button');


function onSubmit(e){

  e.preventDefault();
  if (submitButton.textContent == 'Submit') {
    addBook();
  } else {
    editBook(e)
    form.reset();
    h3.textContent = 'FORM';
    form.removeAttribute('id');
    submitButton.textContent = 'Submit';
  }

   getBooks()

}

async function editBook(e){
  const formData = new FormData(e.target)
  const id = form.getAttribute('id')
  const url = 'http://localhost:3030/jsonstore/collections/books/' + id
  if (formData.get('author') != '' && formData.get('title') != '') {
    const book = {
      author: formData.get('author'),
      title: formData.get('title')
      }
  
    const request = await fetch(url,{
      method: 'put',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(book)
    });
   
    form.reset()

  }

}

async function addBook(){
  const formData = new FormData(form);
    if (formData.get('title') != '' && formData.get('author') != ''){
        const book = {
            author: formData.get('author'),
            title: formData.get('title')
        }
        await fetch('http://localhost:3030/jsonstore/collections/books/', {
            method: 'post',
            headers: {'Content-type': 'application/json'},
            body: JSON.stringify(book)
        });

       form.reset() 
    }
   
}

async function getBooks() {
    const tableBody = document.querySelector('tbody')
    tableBody.replaceChildren()

    const url = 'http://localhost:3030/jsonstore/collections/books/';

    const response = await fetch(url);
    const books = await response.json();
    if (Object.keys(books).length > 0) {
        for (let [id, book] of Object.entries(books)){
            
            const bookTr = createElement('tr', {id: id},
              createElement('td', {}, book.title),
              createElement('td', {}, book.author),
              createElement('td', {}, createElement('button', {}, 'Edit'), createElement('button', {}, 'Delete')))
    
            tableBody.appendChild(bookTr)
            bookTr.addEventListener('click', editOrDelete)
    
        }

    }


}



function editOrDelete(event) {
    if (event.target.tagName == 'BUTTON'){
        const targetRow = event.target.parentNode.parentNode  
        const buttonName = event.target.textContent
        if (buttonName == 'Delete') {
            deleteBook(targetRow.id)
        }else {
            editForm(targetRow.id)
        }
    }
    getBooks()
}

async function editForm(id) {
    const url = 'http://localhost:3030/jsonstore/collections/books/' + id

    h3.textContent = 'EditForm';

    const title = document.querySelector('[name=title]');
    const autor = document.querySelector('[name=author]')
    form.setAttribute('id', id)

    submitButton.textContent = 'Save';

    const response = await fetch(url);
    const book = await response.json();
    title.value = book.title;
    autor.value = book.author;
    
}

async function deleteBook(id) {
    const url = 'http://localhost:3030/jsonstore/collections/books/' + id

    await fetch(url, {
        method: 'delete'
    })
}



function createElement(type, atributes, ...values) {
  const element = document.createElement(type);

  for (let [a, v] of Object.entries(atributes)) {
    if (a == "className") {
      for (let c of v) {
        element.classList.add(c);
      }
    } else {
      element.setAttribute(a, v);
    }
  }

  for (let value of values) {
    if (typeof value == "string" || typeof value == "number") {
      const textNode = document.createTextNode(value);
      element.appendChild(textNode);
    } else {
      element.appendChild(value);   
    }
  }

  return element;
}

