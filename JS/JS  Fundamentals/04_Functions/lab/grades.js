 function solve(grade) {
    let description = '';
    if (grade < 3) {

        description = 'Fail';
    } else if (grade >= 3 && grade < 3.5) {
        description = 'Poor';

    } else if(grade >= 3.5 && grade < 4.5) {
        description = 'Good';

    } else if(grade >= 4.5 && grade < 5.5) {
        description = 'Very good';
    } else {
        description = 'Exellent';
    }
    
    console.log(`${description} (${grade.toFixed(2)})`)
 }

 solve(3.33)
 solve(4.50)
 solve(2.99)