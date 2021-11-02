function solve(start, end_){
    let sum = 0
    let arr = []
    for (let i = start; i <= end_; i++){
        arr.push(i)
        sum += i
    }
    console.log(arr.join(' '))
    console.log('Sum: ' + sum)
}

solve(0, 26)