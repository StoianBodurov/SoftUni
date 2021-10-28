function solve(speed, area) {
    const motorwaySpeed = 130;
    const interstateSpeed = 90;
    const citySpeed = 50;
    const residentialSpeed = 20;
    let limitSpeed;

    if (area === 'motorway') {
        limitSpeed = motorwaySpeed;

    } else if (area === 'interstate') {
        limitSpeed = interstateSpeed;

    }else if (area === 'city') {
        limitSpeed = citySpeed;

    }else if (area === 'residential') {
        limitSpeed = residentialSpeed;

    }

    let difference = speed - limitSpeed;
    let status;

    if (difference <= 0) {
        console.log(`Driving ${speed} km/h in a ${limitSpeed} zone`);
        return

    }else if (difference <= 20) {
        status = 'speeding';

    } else if (difference <= 40 && difference >20 ){
        status = 'excessive speeding';

    } else {
        status = 'reckless driving';
    }
    console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limitSpeed} - ${status}`)
}


solve(40, 'city')
solve(21, 'residential')
solve(120, 'interstate')
solve(200, 'motorway')