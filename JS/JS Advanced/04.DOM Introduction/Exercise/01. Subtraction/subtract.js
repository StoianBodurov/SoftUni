function subtract() {
   let first = document.getElementById('firstNumber').value;
   let second = document.getElementById('secondNumber').value;
   

   let result = Number(first) - Number(second);
   let el = document.getElementById('result');
    console.log(el)
    console.log(result)
    el.textContent = result;

}