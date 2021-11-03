function solve(num){
    let sum = 0;
    while (num > 0){
        let digit =  num % 10; 
        num = Math.trunc(num / 10);
        sum += digit;
    }
    console.log(sum);
}


solve(543)