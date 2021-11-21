function attachEvents() {
   const createButton = document.getElementById('btnCreate').addEventListener('click', createContact);
   const loadButton = document.getElementById('btnLoad').addEventListener('click', loadContact);
}

attachEvents();


async function createContact() {
    const personArea = document.getElementById('person');
    const phoneArea = document.getElementById('phone');
   

    const contact = {
        "person": personArea.value,
        "phone": phoneArea.value
    }

    if (personArea.value != '' && phoneArea.value != '') {
        await fetch('http://localhost:3030/jsonstore/phonebook', 
        {method: 'post',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(contact)
    });
        
    personArea.value = '';
    phoneArea.value = '';
    }

}


async function loadContact() {
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const contacts = await response.json();
    const ul = document.getElementById('phonebook');

    ul.replaceChildren()

    for (let [k, v] of Object.entries(contacts)) {
       const li = createElement('li', {id: k}, `${v.person}: ${v.phone}`)
       const deleteButton = createElement('button', {}, 'Delete');
       deleteButton.addEventListener('click', deleteContact);

       li.appendChild(deleteButton)
       ul.appendChild(li)
    }
}

async function deleteContact(event){
    const id = event.target.parentNode.id
    const url = 'http://localhost:3030/jsonstore/phonebook/' + id

    await fetch(url, {
        method: 'delete'
    });

    loadContact();
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