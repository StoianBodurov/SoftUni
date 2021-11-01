function solve(num1, num2, num3) {
    let largesNumber;
    if (num1 > num2 && num1 > num3) {
        largesNumber = num1;
    }else if (num2 > num1 && num2 > num3) {
        largesNumber = num2;
    } else {
        largesNumber = num3;
    }
    console.log(`The largest number is ${largesNumber}.`);
}

solve(5, -3, 16);
solve(-3, -5, -22.5);