function solve(firstChar, secondChar) { 
    startNumber = firstChar.charCodeAt();
    endNumber = secondChar.charCodeAt();
    const result = [];
    if (startNumber > endNumber){
        startNumber = secondChar.charCodeAt();
        endNumber = firstChar.charCodeAt();

    }

    for (let i = startNumber + 1; i < endNumber; i++) {
        result.push(String.fromCharCode(i));
    }

    console.log(result.join(' '))

}

solve('a', 'd')
solve('#', ':')
solve('C', '#')