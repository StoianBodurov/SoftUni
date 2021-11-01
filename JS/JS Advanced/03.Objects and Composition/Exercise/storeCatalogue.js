function solve(data) {
    data.sort()
    const catalog = {}
    for (let el of data){
        let [product, price] = el.split(' : ')
        if (! catalog.hasOwnProperty(product[0])){
            catalog[product[0]] = []
        }
        catalog[product[0]][product] = Number(price)

    }
    for (let el in catalog){
        console.log(el)
        for (let e in catalog[el]){
            console.log(`${e}: ${catalog[el][e]}`)
        }
    }

}


solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);