function solve(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice){
    let expenses = 0;
    let brokenShieldCount = 0;

    for (let i = 1; i <= lostFightsCount; i++){
        if (i % 2 === 0){
            expenses += helmetPrice;
        }

        if (i % 3 === 0){
            expenses += swordPrice;
        }

        if (i % 2 === 0 && i % 3 === 0){
            expenses += shieldPrice;
            brokenShieldCount += 1;
        }

        if (brokenShieldCount === 2){
            expenses += armorPrice;
            brokenShieldCount = 0
        }

    }
    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`)
}


solve(7, 2, 3, 4, 5)
solve(23, 12.5, 21.5, 40, 200)