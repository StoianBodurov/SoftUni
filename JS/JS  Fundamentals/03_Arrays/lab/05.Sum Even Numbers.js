function solve(arr){
    let evenSum = 0;
    for (el of arr){
        let num = Number(el)
        if (num % 2 == 0){
            evenSum += num;
        }
    }
    console.log(evenSum);
}


solve(['1','2','3','4','5','6'])