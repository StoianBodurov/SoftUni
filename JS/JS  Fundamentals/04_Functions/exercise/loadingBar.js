function solve(n) {
    if (n == 100) {
        console.log('100% Complete!')
    } else {
        const result = [];
        for (let i = 0; i < n / 10; i++){
            result.push('%')
        }

        for (let i = 0; i < (100 - n) / 10; i++) {
            result.push('.')
        }
        console.log(`${n}% [${result.join('')}]`)
        console.log('Still loading...')
        
    }

}

solve(30)
solve(100)
solve(90)
solve(0)