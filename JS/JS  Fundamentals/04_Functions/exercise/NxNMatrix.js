function solve(n) {
    const result = [];
    for (let i = 0; i < n; i++) {
        const row = [];
        for (let j = 0; j < n; j++) {
            row.push(n)
        }
        result.push(row.join(' '))
    }

    console.log(result.join('\n'))
}

solve(7)