function greatestCommonDivisor(num1, num2) {
    let smallerNum = NaN;
    let greatestDivisor = 1
    if (num1 < num2) {
        smallerNum = num1;
    }else {
        smallerNum = num2
    }
    for (let i = 1; i <= smallerNum; i++) {
        if (num1 % i === 0 && num2 % i === 0) {
            greatestDivisor = i
        }
    }
    console.log(greatestDivisor)
}

greatestCommonDivisor(15, 5)

greatestCommonDivisor(2154, 458)