function solve(number, precision){
    if (precision > 15){
        precision = 15
    }
    console.log(parseFloat(number.toFixed(precision, number)))
}

solve(3.5454666, 0)