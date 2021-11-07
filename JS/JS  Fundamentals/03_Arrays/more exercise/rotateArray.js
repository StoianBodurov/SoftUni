function solve(data) {
    const rotates = Number(data.pop());

    for (let i = 0; i < rotates; i++) {
        data.unshift(data.pop());
    }

    console.log(data.join(' '));
}


solve(['1', '2', '3', '4', '2']);
solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']);