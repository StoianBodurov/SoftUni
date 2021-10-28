function solve(input) {
    const cities = {}
    const products = {}


    for (let el of input) {
        let [townName, productName, productPrice] = el.split(' | ')
        if (!cities.hasOwnProperty(townName)){
            cities[townName] = {}
        }
    
        cities[townName][productName] = Number(productPrice)
        if (!products.hasOwnProperty(productName)){
            products[productName] = {}
            products[productName]['price'] = Number.MAX_SAFE_INTEGER
            products[productName]['city'] = townName
        }
    


    }
    for (let city in cities) {

        for (let product in cities[city])
            if (products[product]['price'] > cities[city][product] ){
                products[product]['city'] = city
                products[product]['price'] = cities[city][product]
            }
            
    }
    for (let product in products){
        console.log(`${product} -> ${products[product]['price']} (${products[product]['city']})`)
    }
   
}

solve(
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);