function fruit(fruit, quantity, price) {
    let weightKg = quantity / 1000;
    let totalPrice = weightKg * price;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`)

}

fruit('orange', 2500, 1.80)
fruit('apple', 1563, 2.35)