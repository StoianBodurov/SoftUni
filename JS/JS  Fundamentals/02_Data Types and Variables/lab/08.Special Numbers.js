function solve(n){
    for (let i = 1; i <= n ; i++){
        let num = i.toString();
        let sum = 0
        for (let j = 0; j < num.length; j++){
            sum += Number(num[j]);
        }
        if (sum == 5 || sum == 7 || sum == 11){
            console.log(`${num} -> True`)

        } else {
            console.log(`${num} -> False`)
        }

    }
}

solve(15)