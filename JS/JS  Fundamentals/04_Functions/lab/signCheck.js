function solve(num1, num2, num3) {
    let result = '';


    if ((num1 >= 0 && num2 >= 0 && num3 < 0) || (num1 >= 0 && num2 < 0 && num3 >= 0) || (num1 < 0 && num2 >= 0 && num3 >= 0) || (num1 < 0 && num2 < 0 && num3 < 0)){
        result = 'Negative'
    }else{
        result = 'Positive'
    }
    console.log(result)
}

solve(5, 12, -15)
solve(-6, -12, 14)
solve(-1, -2, -3)