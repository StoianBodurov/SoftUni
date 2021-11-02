function solve(n){
    for (let i = 0; i < n; i++){
        for (let j = 0; j < n; j++){
            for (let k = 0; k < n; k++){
                let leter1 = String.fromCharCode(97 + i)
                let leter2 = String.fromCharCode(97 + j)
                let leter3 = String.fromCharCode(97 + k)
                console.log(leter1 + leter2 + leter3)
            }

        }
    }
}

solve(3)