function solve(n) {
    for (let row = 1; row <= n; row++){
        let r = ''
        for (let j = 0; j < n; j++) {
            r +='* '
        }
        console.log(r)
    }
}

solve(5)