function attachEvents() {

    const submitButton = document.getElementById('submit');
    
    submitButton.addEventListener('click', getWeather)
}

attachEvents();



async function getWeather() {

    const forecastSymbols = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast':	'☁',
        'Rain':	'☂',
        'Degrees': '°'
    }

    const forecastDiv = document.getElementById('forecasts');
    const location = document.getElementById('location').value;
    const currentConditondiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');

    currentConditondiv.textContent = '';
    upcomingDiv.textContent = '';
   
    try {
        
        const response = await fetch(`http://localhost:3030/jsonstore/forecaster/locations`);
        const locations = await response.json();

        const cityCode = Array.from(locations).find(l => l.name.toLowerCase() == location.toLowerCase()).code;

        const currentCondition = await getWeatherCondition(cityCode, 'http://localhost:3030/jsonstore/forecaster/today/');
        const threeDayForecast = await getWeatherCondition(cityCode, 'http://localhost:3030/jsonstore/forecaster/upcoming/');


        const divCurent = document.createElement('div');
        divCurent.classList.add('forecasts');
        currentConditondiv.appendChild(divCurent);

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition-symbol');
        symbolSpan.textContent = forecastSymbols[currentCondition.forecast.condition];
        divCurent.appendChild(symbolSpan);

        const fullDataSpan = document.createElement('span');
        fullDataSpan.classList.add('condition');
        divCurent.appendChild(fullDataSpan);

        const citySpan = document.createElement('span');
        citySpan.classList.add('forecast-data');
        citySpan.textContent = currentCondition.name;
        fullDataSpan.appendChild(citySpan);

        const tempSpan = document.createElement('span');
        tempSpan.classList.add('forecast-data');
        tempSpan.textContent = `${currentCondition.forecast.low}${forecastSymbols['Degrees']}/${currentCondition.forecast.high}${forecastSymbols['Degrees']}`;
        fullDataSpan.appendChild(tempSpan);

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('forecast-data');
        conditionSpan.textContent = currentCondition.forecast.condition;
        fullDataSpan.appendChild(conditionSpan)

        const forecastInfoDiv = document.createElement('div');
        forecastInfoDiv.classList.add('forecast-info');
        upcomingDiv.appendChild(forecastInfoDiv);

        const upcomingSpan = document.createElement('span');
        upcomingSpan.classList.add('upcoming');
        forecastInfoDiv.appendChild(upcomingSpan)

        for (let data of threeDayForecast.forecast){

            const symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.textContent = forecastSymbols[data.condition];
            upcomingSpan.appendChild(symbolSpan)

            const tempSpan = document.createElement('span');
            tempSpan.classList.add('forecast-data');
            tempSpan.textContent = `${data.low}${forecastSymbols['Degrees']}/${data.high}${forecastSymbols.Degrees}`;
            upcomingSpan.appendChild(tempSpan)

            const conditionSpan = document.createElement('span');
            conditionSpan.classList.add('forecast-data');
            conditionSpan.textContent = data.condition;
            upcomingSpan.appendChild(conditionSpan);
        }

        forecastDiv.style.display = '';
    }catch(error) {
        currentConditondiv.innerHTML = '';
        currentConditondiv.textContent = 'Error';
        forecastDiv.style.display = '';
    }  
    document.getElementById('location').value = ''

}


async function getWeatherCondition(code, url) {
    const response = await fetch(url + code);
    const data = await response.json();

    return data;
}

