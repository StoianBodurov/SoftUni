function solve(input) {
    const food = {}

    for (let i = 0;  i < input.length; i += 2) {
        key = input[i]
        value = Number(input[i + 1])
        food[key] = value

    }
    console.log(food)
}


solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42'])