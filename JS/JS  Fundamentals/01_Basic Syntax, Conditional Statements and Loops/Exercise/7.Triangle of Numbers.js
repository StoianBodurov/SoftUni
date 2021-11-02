function solve(n){
    for (let i = 1; i <= n; i++){
        let arr = []
        for (let j = 1; j <= i; j++){
            arr.push(i)
        }

        console.log(arr.join(' '))
    }
}


solve(5)