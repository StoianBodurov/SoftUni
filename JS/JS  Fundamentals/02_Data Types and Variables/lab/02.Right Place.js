function solve(string, char, template){
    let result = string.replace('_', char);
    if (result == template){
        console.log(`Matched`);
    } else {
        console.log(`Not Matched`);
    }

}


solve('Str_ng', 'I', 'Strong')
solve('Str_ng', 'i', 'String')