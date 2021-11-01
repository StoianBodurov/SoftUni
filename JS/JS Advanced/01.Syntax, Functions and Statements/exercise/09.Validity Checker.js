function solve(x1, y1, x2, y2) {
    let z01 = Math.sqrt(x1 ** 2 + y1 ** 2);
    let z02 = Math.sqrt(x2 ** 2 + y2 ** 2);
    let z12 = Math.sqrt(Math.abs((x1 - x2) ** 2 + Math.abs((y1 - y2) ** 2)));

    if (parseInt(z01) == z01) {
        console.log(`{${x1}, ${y1}} to {${0}, ${0}} is valid`);
    
    } else {
        console.log(`{${x1}, ${y1}} to {${0}, ${0}} is invalid`);
    }
    if (parseInt(z02) == z02) {
        console.log(`{${x2}, ${y2}} to {${0}, ${0}} is valid`);
    
    } else {
        console.log(`{${x2}, ${y2}} to {${0}, ${0}} is invalid`);
    }
    if (parseInt(z12) == z12) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }

}

solve(3, 0, 0, 4);
console.log('-----------');
solve(2, 1, 1, 1);