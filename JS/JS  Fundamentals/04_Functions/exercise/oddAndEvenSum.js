function solve(number) {
    const numberToString = String(number);
    let oddSum = 0;
    let evenSum = 0;
    
    for (let n of numberToString) {
        const  num = Number(n);
        if (num % 2 == 0) {
            evenSum += num;
        } else {
            oddSum += num
        }
    }

    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`
}


console.log(solve(1000435));
console.log(solve(3495892137259234));