function calculator() {

  let firstNumber
  let secondNimber
  let resultField

  function init(selector1, selector2, selector3){
    firstNumber = document.querySelector(selector1)
    secondNimber = document.querySelector(selector2)
    resultField = document.querySelector(selector3)

  }

  function add() {
    resultField.value = Number(firstNumber.value)+ Number(secondNimber.value)

  }

  function subtract() {

    resultField.value = Number(firstNumber.value) - Number(secondNimber.value)
  }

  return {init, add, subtract}

}


const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result');
