function addSubtract(num1, num2, num3) {

    function add(n1, n2) {
        return n1 +n2;
    }

    function subtract(n1, n2) {
        return n1 - n2;
    }
    return subtract(add(num1, num2), num3);
}


console.log(addSubtract(23, 6, 10));

console.log(addSubtract(1, 17, 30));

console.log(addSubtract(42, 58, 100));