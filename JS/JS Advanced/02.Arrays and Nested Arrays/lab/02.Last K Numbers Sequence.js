function solve(n, k) {
    const result = [1];
    for (let i = 0; i < n - 1; i++) {
        let sum = 0;
        for (let j = i; j > i - k; j--) {
            if (result[j] !== undefined) {
                sum += result[j];
            }
        }
        result.push(sum);
    }
    return result;
}

console.log(solve(6, 3));
console.log(solve(8, 2));