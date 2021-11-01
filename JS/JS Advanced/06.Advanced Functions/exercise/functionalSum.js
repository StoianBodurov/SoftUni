function add(n) {
    let result = n

    function sum(m) {
        result += m
        return sum
    }

    sum.toString = () => {
        return result
    }

    return sum
}
console.log(add(3)(4)(2)(5).toString());