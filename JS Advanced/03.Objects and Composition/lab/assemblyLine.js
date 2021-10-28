function solve(){
    const result= {
        hasClima(car){
        car.temp = 21
        car.tempSettings = 21
        car.adjustTemp = () =>  {
            if (car.tempSettings < car.temp){
                car.temp -= 1;
            } else if(car.tempSettings > car.temp) {
                car.temp += 1;
            }
        }
    }, 
    hasAudio(car){
        car.currentTrack = null;
        car.nowPlaying = () => {
            if (car.currentTrack != null) {
                console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
            }
        }
    },
    hasParktronic(car){
        car.checkDistance = (distance) => {
            if (distance < 0.1) {
                console.log('Beep! Beep! Beep!');
            } else if (distance >= 0.1 && distance < 0.25) {
                console.log('Beep! Beep!');
            } else if (distance >= 0.25 && distance < 0.5) {
                console.log('Beep!');
            }
        }
    }

}
    return result
}


const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};
let k = solve()


k.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

k.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

k.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);