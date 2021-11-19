function solve (num1, num2){
    function factoriel(n) {
        let result = 1;
        for (let i = 1; i <= n; i++){
            result *= i;
        }
        return result
    }
    console.log((factoriel(num1) / factoriel(num2)).toFixed(2))
}

solve(5, 2)

solve(6, 2)