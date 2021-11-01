function solve(n){
    let num = 1
    let oddSum = 0
    while (n > 0){
        if (num % 2 != 0){
            oddSum += num;
            console.log(num);
            n--;
        }
        num++;
    
        

    }
    console.log('Sum: ' + oddSum);
}

solve(5)