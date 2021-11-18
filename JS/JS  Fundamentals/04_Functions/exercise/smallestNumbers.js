function smallestNumber(num1, num2, num3) {
    let smallest;
    if (num1 < num2 && num1 < num3){
        smallest = num1;

    } else if (num2 < num1 && num2 < num3) {
        smallest = num2;
    } else {
        smallest = num3;
    }

    console.log(smallest)

}


smallestNumber(2, 3, 5)
smallestNumber(600, 342, 123)
smallestNumber(25, 21, 4)