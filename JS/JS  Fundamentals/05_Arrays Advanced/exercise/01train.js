function solve(arr) {

    const [data, wagonCapacity, ...commands] = arr
    const wagonCount = data.split(' ').map(Number)

    for (let token of commands) {
        let [command, passengers] = token.split(' ');

        if (command == 'Add') {
            wagonCount.push(Number(passengers))
        } else {
            passengers = Number(command)
            for (let i = 0; i < wagonCount.length; i++) {
                if (wagonCount[i] + passengers <= Number(wagonCapacity)) {
                    wagonCount[i] += passengers;
                    break
                }
            }
        }
    }
    console.log(wagonCount.join(' '))
}


solve([
    '32 54 21 12 4 0 23',
    '75',
    'Add 10',
    'Add 0',
    '30',
    '10',
    '75'
])

solve([
    '0 0 0 10 2 4',
    '10',
    'Add 10',
    '10',
    '10',
    '10',
    '8',
    '6'
])