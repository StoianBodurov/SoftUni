function solve(commands) {
    const result = [];
    let initNumber = 1;

    for (let command of commands) {
        if (command == 'add') {
            result.push(initNumber);
          
        } else {
            result.pop()
        }
        initNumber += 1;
    }

    if (result.length != 0) {
        console.log(result.join(' '));
    } else {
        console.log('Empty')
    }

}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);