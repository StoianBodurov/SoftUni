function solve(name, population, treasury) {
    const city = {};
    city.name = name;
    city.population = population;
    city.treasury = treasury;

    return city;
}


console.log(solve('Tortuga', 7000, 15000));
console.log(solve('Santo Domingo', 12000, 23500));