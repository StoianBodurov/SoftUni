viewStudents()
const submitButton = document.getElementById('submit').addEventListener('click', addStudent);

async function viewStudents() {

    const response = await fetch('http://localhost:3030/jsonstore/collections/students')
    const data = await response.json();

    const table = document.querySelector('tbody')  
    table.replaceChildren()

    for (let student of Object.values(data)) {
      const row = createElement('tr', {}, createElement('td', {}, student.firstName),
          createElement('td', {}, student.lastName),
          createElement('td', {}, student.facultyNumber),
    createElement('td', {}, student.grade));
    
      table.appendChild(row);

    } 
    
  }
  
  async function addStudent(e) {
    e.preventDefault()
    const firstNameInput = document.querySelector('[name=firstName]');
    const lastNameInput = document.querySelector('[name=lastName]');
    const facultyNumberInput = document.querySelector('[name=facultyNumber]');
    const gradeInput = document.querySelector('[name=grade]');

  if (firstNameInput.value != '' && lastNameInput.value != '' && facultyNumberInput.value != '' && gradeInput.value != '') {

    const student = {
      firstName: firstNameInput.value,
      lastName: lastNameInput.value,
      facultyNumber: facultyNumberInput.value,
      grade: gradeInput.value
    }

    await fetch('http://localhost:3030/jsonstore/collections/students', {
      method: 'post',
      headers: {'Content-type': 'application/json'},
      body: JSON.stringify(student)
    })


    firstNameInput.value = '';
    lastNameInput.value = '';
    facultyNumberInput.value = '';
    gradeInput.value = '';
  }
  viewStudents()
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