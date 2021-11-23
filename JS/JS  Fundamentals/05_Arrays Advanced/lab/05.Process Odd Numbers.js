function solve(inputArr) {
    let oddIndexArray = [];
    for (let i = 0; i < inputArr.length; i++) {
        if (i % 2 != 0) {
            oddIndexArray.push(inputArr[i] * 2)
        }
    }
    console.log(oddIndexArray.reverse().join(' '))
}

solve([10, 15, 20, 25])

solve([3, 0, 10, 4, 7, 3])