function solve() {

    const infoBox = document.getElementById('info');
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');
    let stop = {next: 'depot'}

    async function depart() {

        const url = 'http://localhost:3030/jsonstore/bus/schedule/' + stop.next;

        const response = await fetch(url);
        const data = await response.json();

        stop = data;
        infoBox.textContent = `Next stop ${stop.name}`

        departButton.disabled = true;
        arriveButton.disabled = false;


    }

    function arrive() {
        
        infoBox.textContent = `Arriving at ${stop.name}`

        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();