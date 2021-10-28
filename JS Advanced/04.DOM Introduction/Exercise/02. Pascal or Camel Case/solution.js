function solve() {
  let text = document.getElementById('text').value.split(' ');
  let convention = document.getElementById('naming-convention').value;
  const result = []
  let start

  if (convention === 'Camel Case') {
    start = 1
    result.push(text[0][0].toLowerCase() + text[0].slice(1).toLowerCase())

  } else if (convention === 'Pascal Case'){
    start = 0
  } else {
    result.push('Error!')
  }

  for (let i = start; i < text.length; i++){
    let data = text[i][0].toUpperCase() + text[i].slice(1).toLowerCase();
    result.push(data)
 
  }

  let printResult = document.getElementById('result');
  printResult.textContent = result.join('');



}