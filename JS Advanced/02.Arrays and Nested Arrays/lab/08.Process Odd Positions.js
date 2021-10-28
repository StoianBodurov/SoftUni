function solve(arr) {
    const oddIndexElements = arr.filter((v, i) => i % 2 !== 0);
    const doubleElements = oddIndexElements.map(x => x *2 );
    return doubleElements.reverse().join(' ');
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));