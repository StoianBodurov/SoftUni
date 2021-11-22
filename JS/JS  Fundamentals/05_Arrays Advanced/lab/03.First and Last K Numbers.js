function solve(inputArr) {
    let n = inputArr.shift();
    let firsElements = inputArr.slice(0, n);
    let lastElements = inputArr.slice(-n)

    console.log(firsElements.join(' '))
    console.log(lastElements.join(' '))

 
}

solve([2,7, 8, 9])
solve([3, 6, 7, 8, 9])