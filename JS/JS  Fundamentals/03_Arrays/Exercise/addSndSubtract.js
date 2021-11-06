function solve(arr) {

    const resultArr = []
    let sumOriginalArray = 0;
    let sumModifiedarrtay = 0;

    for (let i = 0; i < arr.length; i++) {
        let resultNum;

        if (arr[i] % 2 == 0) {
            resultNum = (arr[i] + i);

        } else {
            resultNum = (arr[i] - i);
        }
        resultArr.push(resultNum);
        sumModifiedarrtay += resultNum;
        sumOriginalArray += arr[i];


    }

    console.log(resultArr);
    console.log(sumOriginalArray);
    console.log(sumModifiedarrtay);
}

solve([5, 15, 23, 56, 35])

solve([-5, 11, 3, 0, 2])