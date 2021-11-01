function solve(arr) {
    arr.sort()
    arr.sort((a, b) => a.length - b.length)
    console.log(arr.join('\n'))
}

solve(['alpha', 
    'beta', 
    'gamma']);

console.log('-----------');

solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']);

console.log('-----------');

solve(['test', 
'Deny', 
'omen', 
'Default']);
