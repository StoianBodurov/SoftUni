function solve(data) {
    const matrix = []
    const json = []

    for (let el of data) {
        let r = el.split('|')
        let list = []
        for (let e of r) {
            if (e) {
                list.push(e.trim())
            
            }
        }
        matrix.push(list)
    }
    for (let r = 1; r < matrix.length; r++) {
        const temp = {}
        for (let c =0 ; c < matrix[0].length; c++){
           let result = matrix[r][c]
           if (Number(result) ){
               result = Number(result).toFixed(2)
               result = parseFloat(result)
           }
            temp[matrix[0][c]] = result
        }
        json.push(temp)

    }
    
        console.log(JSON.stringify(json))
    
}

solve([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'])