function solve(input) {
    const result = {};

    for (let el of input) {
        let [townName, townPopulation] = el.split(' <-> ');
        townPopulation = Number(townPopulation);

        if (!(townName in result)){
            result[townName] = 0;
        }

            
        result[townName] += townPopulation;
    }
    for (let key in result){
        console.log(`${key} : ${result[key]}`)
    }

}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000'])

console.log('--------------')

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000'])