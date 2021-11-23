function solve(n, k) {
    let result = [1]
    for (let i = 1; i < n; i++) {
        let start = i - k;
        if (start < 0) {
            start = 0;
        }
        let end = i - 1;
        let sum = 0
        for (let j = start; j <= end;j++) {
            sum += result[j]
        }
        result.push(sum)

    }
    console.log(result.join(' '))
}

solve(6, 3)

solve(8, 2)