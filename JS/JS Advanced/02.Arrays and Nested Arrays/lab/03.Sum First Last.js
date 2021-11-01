function solve(numbers) {
    let firstElement = Number(numbers.shift())
    let lastElement = Number(numbers.pop())

    return firstElement + lastElement
}

console.log(solve(['20', '30', '40']))
console.log(solve(['5', '10']))                                                         