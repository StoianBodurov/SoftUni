function solve(arr) {
    let sum = 0;
    let inverseSum = 0;
    let concat = '';

    for (let el of arr) {
        sum += el;
        inverseSum += 1/el;
        concat += el.toString();
    }
    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}

solve([1, 2, 3])
solve([2, 4, 8, 16])