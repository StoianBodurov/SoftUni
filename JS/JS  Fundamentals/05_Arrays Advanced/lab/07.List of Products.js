function solve(inputArray) {
    inputArray.sort();
    for (let i = 0; i < inputArray.length; i++) {
        console.log(`${i + 1}.${inputArray[i]}`)
    }
}


solve(["Potatoes", "Tomatoes", "Onions", "Apples"])