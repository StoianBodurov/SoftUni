function solve(moves) {
    const dashbord = [['false', 'false', 'false'],
                    ['false', 'false', 'false'],
                    ['false', 'false', 'false']];

    const firstPlayer = 'X';
    const secondPlayer = 'O';
    let  counter = 1
    let isNoWiner = true
    let moveCounter = 0


    for (let el of moves) {
        let token = el.split(' ');
        let row = Number(token[0]);
        let col = Number(token[1]);

        if (moveCounter >= 9) {
            break;
        }

        if (dashbord[row][col] == 'false') {
            if (counter % 2 === 0) {
                dashbord[row][col] = secondPlayer
                moveCounter += 1;
            } else {
                dashbord[row][col] = firstPlayer
                moveCounter +=1;
            }
            } else {
                console.log('This place is already taken. Please choose another!')
                counter -= 1
            }

        
        counter += 1;
        if ((dashbord[0][0] == firstPlayer && dashbord[0][1] == firstPlayer && dashbord[0][2] == firstPlayer) || (dashbord[0][0] == secondPlayer && dashbord[0][1] == secondPlayer && dashbord[0][2] == secondPlayer)) {
            
            console.log(`Player ${dashbord[0][0]} wins!`);
            for (let el of dashbord) {
                console.log(el.join('\t'));
                isNoWiner = false
            
        }   
            break;        
        
        } else if((dashbord[1][0] == firstPlayer && dashbord[1][1] == firstPlayer && dashbord[1][2] == firstPlayer) || (dashbord[1][0] == secondPlayer && dashbord[1][1] == secondPlayer && dashbord[1][2] == secondPlayer)) {
            console.log(`Player ${dashbord[1][0]} wins!`);
            for (let el of dashbord) {
                console.log(el.join('\t'));
                isNoWiner = false
            

        }
            break;
        } else if((dashbord[2][0] == firstPlayer && dashbord[2][1] == firstPlayer && dashbord[2][2] == firstPlayer) || (dashbord[2][0] == secondPlayer && dashbord[2][1] == secondPlayer && dashbord[2][2] == secondPlayer)) {
            console.log(`Player ${dashbord[2][0]} wins!`);
            for (let el of dashbord) {
                console.log(el.join('\t'));
                isNoWiner = false
                
        }
            break;
        } else if((dashbord[0][0] == firstPlayer && dashbord[1][1] == firstPlayer && dashbord[2][2] == firstPlayer) || (dashbord[0][0] == secondPlayer && dashbord[1][1] == secondPlayer && dashbord[2][2] == secondPlayer)){
            console.log(`Player ${dashbord[0][0]} wins!`);
            for (let el of dashbord) {
                console.log(el.join('\t'));
                isNoWiner = false
        
        }
            break;    
}
}   
    if (isNoWiner) {
        console.log('The game ended! Nobody wins :(')
    for (let el of dashbord) {
        console.log(el.join('\t'))
    }
    }
}


solve(["0 1",
 "0 0",
 "0 2", 
 "2 0",
 "1 0",
 "1 1",
 "1 2",
 "2 2",
 "2 1",
 "0 0"]
)
console.log('-----------')

solve(["0 0",
 "0 0",
 "1 1",
 "0 1",
 "1 2",
 "0 2",
 "2 2",
 "1 2",
 "2 2",
 "2 1"])

 console.log('------------')

 solve(["0 1",
 "0 0",
 "0 2",
 "2 0",
 "1 0",
 "1 2",
 "1 1",
 "2 1",
 "2 2",
 "0 0"])