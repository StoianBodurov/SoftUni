function solve(input) {
    const heroes = []

    for (let el of input){
        let [heroName, heroLevel, items] = el.split(' / ')
        items = items ? items.split(', ') : []
        let hero = {'name': heroName, 'level': Number(heroLevel), 'items': items}
        heroes.push(hero)
    }
    return JSON.stringify(heroes)

}


console.log(solve([
    'Isacc / 25 ',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']))