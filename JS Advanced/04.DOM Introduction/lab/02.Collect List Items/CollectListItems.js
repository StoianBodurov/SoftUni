function extractText() {
const list = document.querySelectorAll('ul#items li')
    const text = document.getElementById('result')
    for (let el of list){
        text.value += el.textContent + '\n'
    }

    
    
}