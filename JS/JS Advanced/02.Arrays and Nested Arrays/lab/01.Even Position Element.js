function solve(inputArray) {
    const evenPositionNumber = [];
    for (let i = 0; i < inputArray.length; i++) {
        if (i % 2 === 0) {
            evenPositionNumber.push(inputArray[i])
        }
    }
    console.log(evenPositionNumber.join(' '))
}

solve(['20', '30', '40', '50', '60'])
console.log('-----------')
solve(['5', '10'])