function solve(matrix) {
    let maxNumber = -  Number.MAX_SAFE_INTEGER
    for (let row of matrix) {
        let sortedRow = row.sort((a, b) => a - b)
        let maxRowNumber = sortedRow[sortedRow.length - 1]
        if (maxNumber < maxRowNumber) {
            maxNumber = maxRowNumber
        }
    }
    return maxNumber
}


console.log(solve([[20, 50, 10],
    [8, 33, 145]]))


console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
))