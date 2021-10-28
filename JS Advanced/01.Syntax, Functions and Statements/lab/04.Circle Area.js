function solve(n) {
    let typeArgument = typeof(n)
    if (typeArgument !== 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeArgument}.`)
    } else {
        let circleArea = n ** 2 * Math.PI
        console.log(circleArea.toFixed(2))
    }

}

solve('sdgs')
solve(5)
