function sameNumber(num) {
    let numToString = num.toString()
    let sum = Number(numToString[0])

    let isSame = true

    for (let i = 1; i < numToString.length; i++) {
        sum += Number(numToString[i])
        if (numToString[i - 1] !== numToString[i]){
            isSame = false
        }

    }
    console.log(isSame)
    console.log(sum)
}

sameNumber(2222222)
sameNumber(1234)