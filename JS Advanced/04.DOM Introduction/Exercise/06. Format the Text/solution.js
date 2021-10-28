function solve() {
  const textAreContent = document.getElementById('input').value.split('.')
  const outputArea = document.getElementById('output')

  let paragraf = ''
  let count = 0
  let result = ''
  for (let el of textAreContent){
    paragraf += el
    count++
    if (count == 3) {
      result += `<p>${paragraf}.</p>`
      count = 0
      paragraf = ''
    }

  }
  if (paragraf) {
    result += `<p>${paragraf}.</p>`
  }

   outputArea.innerHTML = result
 
}