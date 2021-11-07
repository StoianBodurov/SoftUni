function solve(product, quantity) {
    
    const coffeePrice = 1.50;
    const waterPrice = 1.00;
    const cokePrice = 1.40;
    const snacksPrice = 2.00;

    let result = 0;

    switch(product) {
        case 'coffee':
            result = coffeePrice * quantity;
            break;
        case 'water':
            result = waterPrice * quantity;
            break;
        case 'coke':
            result = coffeePrice * quantity;
            break;
        case 'snacks':
            result = snacksPrice * quantity;
            break;

    }

    console.log(result.toFixed(2))
}

solve('water', 5)
solve('coffee', 2)