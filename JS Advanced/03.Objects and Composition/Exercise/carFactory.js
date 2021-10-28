function solve(order) {
    const model = order.model
    const power = order.power
    const color = order.color
    const carriage = order.carriage
    let wheelsize = order.wheelsize

    if (wheelsize % 2 == 0) {
       wheelsize -= 1
   }


    const result = {
        model: '',
        engine: {power: 0, volume: 0 },
        carriage: {type: '', color: '' },
        wheels: [0, 0, 0, 0]
    }
    const engines = [
        {power: 90, volume: 1800 },
        {power: 120, volume: 2400 },
        {power: 200, volume: 3500 }
    ]

    result.wheels.fill(wheelsize, 0)
    result.model = model
    result.carriage.color = color
    result.carriage.type = carriage

    for (let eng of engines) {
        if (power <= eng.power) {
            result.engine.power = eng.power
            result.engine.volume = eng.volume
            break
        }
    }

    return result
}

const obj = { 
    model: 'VW Golf II',
    power: 110,
    color: 'blue',
    carriage: 'hatchback',
     wheelsize: 17 }


let k = solve(obj)


console.log(k.wheels)