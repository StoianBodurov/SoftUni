function solve(numberSteps, lengthStudentFootprint , speed) {

    let fullDistance = numberSteps * lengthStudentFootprint
    let numberOfBreak = Math.floor(fullDistance / 500)
    let fullTime = fullDistance / (speed / 3.6) + numberOfBreak * 60

    let hors = 0
    let minutes = Math.floor(fullTime / 60)
    let seconds = (fullTime % 60).toFixed()
    
    if (minutes >= 60) {
        hors = Math.floor(minutes / 60)
        minutes %= 60

    }
    if (hors < 10) {
        hors = `0${hors}`
    }

    if (minutes < 10) {
        minutes = `0${minutes}`
    }

    if (seconds < 10) {
        seconds = `0${seconds}`
    }
    console.log(`${hors}:${minutes}:${seconds}`)


}



solve(4000, 0.60, 5)
solve(2564, 0.70, 5.5)

