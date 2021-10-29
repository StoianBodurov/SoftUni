function attachEventsListeners() {

    const daysInput = document.getElementById('days');
    const daysBtn = document.getElementById('daysBtn');

    const hoursInput =document.getElementById('hours');
    const hoursBtn = document.getElementById('hoursBtn');

    const minutesInput = document.getElementById('minutes');
    const minutesBtn = document.getElementById('minutesBtn');

    const secondsInput = document.getElementById('seconds');
    const secondsBtn = document.getElementById('secondsBtn');


    daysBtn.addEventListener('click', daysFunc);
    hoursBtn.addEventListener('click', hoursFunc);
    minutesBtn.addEventListener('click', minutesFunc);
    secondsBtn.addEventListener('click', secondsFunc);

    function daysFunc(ev) {
        const days = Number(daysInput.value);
        
        if (days > 0) {
            hoursInput.value = days * 24
            minutesInput.value = days * 24 * 60
            secondsInput.value = days * 24 * 60 * 60
            console.log(days)
        }

    }

    function hoursFunc(ev) {
        const hours = Number(hoursInput.value);
        daysInput.value = hours / 24
        minutesInput.value = hours * 60
        secondsInput.value = hours * 60 * 60


    }

    function minutesFunc(ev) {
        const minutes = Number(minutesInput.value);
        hoursInput.value = minutes / 60
        daysInput.value = minutes / 60 / 24
        secondsInput.value = minutes * 60


    }

    function secondsFunc(ev) {
        const seconds = Number(secondsInput.value);
        minutesInput.value = seconds / 60
        hoursInput.value = seconds / 60 / 60 
        daysInput.value = seconds / 60 / 60 / 24

    }

 
}