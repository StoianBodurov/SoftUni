function solve(n) {
    let result = 0

    for (let i = 1; i < n ; i++) {
        if (n % i == 0) {
            result += i;
        }
    }

    if (result == n) {
        return 'We have a perfect number!'
    } else {
        return 'It\'s not so perfect.'
    }
  
}

console.log(solve(6))
console.log(solve(28))
console.log(solve(1236498))