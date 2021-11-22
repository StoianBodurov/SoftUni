function solve(inputArr) {
    let sum = Number(inputArr.shift()) + Number(inputArr.pop());

    return sum;
}


console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));