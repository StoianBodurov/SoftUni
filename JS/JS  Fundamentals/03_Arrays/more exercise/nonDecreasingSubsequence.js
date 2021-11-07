function solve(arr) {
    const result = [arr[0]];

    for (let i = 1; i < arr.length; i++) {
        if (result.slice(-1) < arr[i]) {
            result.push(arr[i]);
        }
    }
    console.log(result.join(' '));
}

solve([ 1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve([ 1, 2, 3, 4]);
solve([ 20, 3, 2, 15, 6, 1]);