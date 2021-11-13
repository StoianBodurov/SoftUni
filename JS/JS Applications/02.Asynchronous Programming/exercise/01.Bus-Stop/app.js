async function getInfo() {
    const stopID = document.getElementById('stopId');
    const id = stopID.value;
    const stopName = document.getElementById('stopName');
    const listOfStops = document.getElementById('buses')

    const url = 'http://localhost:3030/jsonstore/bus/businfo/' + id; 

    try {

        listOfStops.innerHTML = '';
        const response = await fetch(url);
        const data = await response.json();

        stopName.textContent = data.name;

        for (let [busID, time] of Object.entries(data.buses)) {
            const liElement = document.createElement('li');
            liElement.textContent = `Bus ${busID} arrives in ${time} minutes`;
            listOfStops.appendChild(liElement);
        }
    
        stopID.value = ''
    } catch (error) {
        stopName.textContent = 'Error'
    }
}