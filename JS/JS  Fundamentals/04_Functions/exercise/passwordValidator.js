function solve(password) {
    const result = [];
    let countOfDigit = 0;

    if (password.length < 6 || password.length > 10){
        result.push('Password must be between 6 and 10 characters');
    }

    for (let char of password) {
        if (char.toLowerCase() == char.toUpperCase() && isNaN(Number(char))) {
            result.push('Password must consist only of letters and digits');
            break;
        }
    }

    for (let char of password) {
        if (!isNaN(Number(char))){
            countOfDigit += 1;
        }
    }

    if (countOfDigit < 2){
        result.push('Password must have at least 2 digits');
    }

    if (result.length == 0) {
        console.log('Password is valid');
    } else {
        console.log(result.join('\n'));
    }
}

solve('logIn');
console.log('--------------');
solve('MyPass123');
console.log('--------------');
solve('Pa$s$s')

