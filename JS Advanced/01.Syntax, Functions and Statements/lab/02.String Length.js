function solve(string1, string2, string3) {
    let sum = string1.length + string2.length + string3.length;
    let averageLength = Math.round(sum / 3);

    console.log(sum);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake')
solve(`pasta`, '5', '22.3')

