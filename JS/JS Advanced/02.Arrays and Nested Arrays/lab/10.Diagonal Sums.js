function solve(matrix) {
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;
    let matrixLength = matrix.length - 1;

    for (let i = 0; i < matrix.length; i ++) {
        firstDiagonalSum += matrix[i][i];
        secondDiagonalSum += matrix[i][matrixLength - i];

    }
    console.log(firstDiagonalSum, secondDiagonalSum);
}


solve([[20, 40],
    [10, 60]])

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]])