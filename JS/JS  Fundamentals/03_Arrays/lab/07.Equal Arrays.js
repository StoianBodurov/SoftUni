function solve(firstAray, secondAray){
    let sum = 0
    let index = NaN
    for (let i = 0; i <= firstAray.length - 1; i++){
        if (firstAray[i] === secondAray[i]){
            sum += Number(firstAray[i])
        } else {
            index = i
            break
        }

    }
    if (isNaN(index)){
        console.log(`Arrays are identical. Sum: ${sum}`)
    } else {
        console.log(`Arrays are not identical. Found difference at ${index} index`)
    }
}

solve['10','20','30'], ['10','20','30']