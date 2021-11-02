function solve(bandName, albumName, songName){
    let songDuration = (albumName.length * bandName.length) * songName.length / 2
    let rotationCount = Math.ceil(songDuration / 2.5)

    console.log(`The plate was rotated ${rotationCount} times.`)

}


solve('Black Sabbath', 'Paranoid', 'War Pigs')