function magicMatrix(matrix) {
    const allSum = [];
    
    for (let row = 0; row < matrix.length; row++ ) {
        let sum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] !== undefined) {
                sum += matrix[row][col];
            }
        }
        allSum.push(sum);
    }

    for (let col = 0; col < matrix[0].length; col++){
        let sum = 0;
        for (let row = 0; row < matrix.length; row++) {
            if (matrix[row][col] !== undefined) {
                sum += matrix[row][col];
            }
        }
        allSum.push(sum);
    }

    if (allSum.every(a => a === allSum[0])) {
        return true;
    } else {
        return false;
    }
}

console.log(magicMatrix([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));

console.log('--------------');

console.log(magicMatrix([[11, 32, 45],
 [21, 0, 1],
 [21, 1, 1]]));

 console.log('--------------');

 console.log(magicMatrix([[1, 0, 0],
 [0, 0, 1],
 [0, 1, 0]]));
