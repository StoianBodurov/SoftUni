function solve (arr) {
    let number = 1;
    const result = [];

    for (let i = 0; i < arr.length; i ++) {
        let command = arr[i];
        if (command == 'add') {
            result.push(number);

        } else if (command == 'remove') {
            result.pop();
        }
        number += 1;

    }
    if (result.length > 0) {
        console.log(result.join('\n'));
    }else {
        console.log('Empty');
    }
}


solve(['add', 
'add', 
'add', 
'add']
)

solve(['add', 
'add', 
'remove', 
'add', 
'add'])


solve(['remove', 
'remove', 
'remove'])