async function solution() {
    const section = document.getElementById('main');
    const data = await getData('http://localhost:3030/jsonstore/advanced/articles/list')
    
    for (let [k, v] of Object.entries(data)){
        const id = v._id;
        const contentData = await getData('http://localhost:3030/jsonstore/advanced/articles/details/' + id)
        const title = contentData.title;
        const content = contentData.content;

        section.appendChild(createElement('div', {className: ['accordion']},
            createElement('div', {className: ['head']},
            createElement('span', {}, `${title}`, createElement('button', {className: ['button'], id: `${id}`}, 'MORE'))),
            (createElement('div', {className: ['extra']},
            createElement('p', {}, `${content}`)))));

    }

    section.addEventListener('click', showMoreLess)
}
    
function showMoreLess(event) {
    const targetElement = event.target
    const div = targetElement.parentNode.parentNode.parentNode

    if (targetElement.tagName == 'BUTTON') {
        const hidenDiv = div.querySelector('.extra')
        if (targetElement.textContent == 'MORE') {
            hidenDiv.style.display = 'block';
            targetElement.textContent = 'LESS'
        }else {
            hidenDiv.style.display = '';
            targetElement.textContent = 'MORE'
    
        }
    
            
    }
}
    
async function getData(url){
    const respons = await fetch(url);
    const data = respons.json();
    
    return data;
}
    
function createElement(type, atributes, ...values){
    const element = document.createElement(type);
    
    for (let [a, v] of Object.entries(atributes)) {
        if (a == 'className') {
            for (let c of v) {
                element.classList.add(c.toLocaleLowerCase());
                }
        } else {
            element.setAttribute(a, v.toLocaleLowerCase());
        }
    }
    
    for (let value of values) {
        if (typeof value == 'string' || typeof value == 'number') {
            const textNode = document.createTextNode(value);
            element.appendChild(textNode);
        }else {
            element.appendChild(value);
        }
    }
    
    return element
}


solution()
