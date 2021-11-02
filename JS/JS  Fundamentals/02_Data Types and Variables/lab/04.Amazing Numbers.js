function solve(number){
    let numberToString = number.toString()
    let sum = 0
    for (let i = 0; i < numberToString.length; i++){
        sum += Number(numberToString[i]);
    }

    let sumToStrin = sum.toString();
    if (sumToStrin.includes('9')){
        console.log(`${number} Amazing? True`);
    } else {
        console.log(`${number} Amazing? False`);

    }
}



solve(1233)
solve(999)