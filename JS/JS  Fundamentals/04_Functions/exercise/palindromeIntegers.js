function solve(data) {

    for (let el of data) {
        if (String(el) == Array.from(String(el)).reverse().join('')) {
            console.log(true)
        } else {
            console.log(false)
        }
    }
    
}

solve([123,323,421,121])
solve([32,2,232,1010])