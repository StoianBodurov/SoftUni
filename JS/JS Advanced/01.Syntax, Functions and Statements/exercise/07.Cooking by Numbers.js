function solve (num, ...param) {
    num = Number(num)

    function operation(op) {
        if (op === 'chop'){
            num /= 2;
        } else if (op === 'dice') {
            num = Math.sqrt(num)
        } else if (op === 'spice') {
            num += 1;
        } else if (op === 'bake') {
            num *= 3;
        } else if (op === 'fillet') {
            num *= 0.8;
        }

    }

    for (let el of param) {
        operation(el)
        console.log(num)
    }

}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')