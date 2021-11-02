function solve(distance, passengersCount, fuelPrice){
    const fuelConsumption = 7
    let totalFuelConsumption = fuelConsumption + (passengersCount * 0.1)
    let tripPrice = (distance / 100) * totalFuelConsumption * fuelPrice

    console.log(`Needed money for that trip is ${tripPrice.toFixed(2)} lv.`);

}


solve(260, 9, 2.49)
solve(90, 14, 2.88)