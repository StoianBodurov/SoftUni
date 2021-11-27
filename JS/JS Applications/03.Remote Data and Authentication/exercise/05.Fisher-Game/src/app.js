window.addEventListener('DOMContentLoaded', () => {
    const user = document.getElementById('user')
    const guest = document.getElementById('guest')
    user.addEventListener('click', onLogout)
    
    
    const loadButton = document.querySelector('aside button').addEventListener('click', onLoad)
    const addform = document.querySelector('#addForm')
    addform.addEventListener('submit', onAdd)
    
    
    onLogon()
    loadCatches()
    
})

const userData = JSON.parse(sessionStorage.getItem('userdata'));



function onLogon() {
    const addBuuton = document.querySelector('.add')
    const userName = document.querySelector('.email span')
    console.log(userName)
    

    
    if (userData) {
        addBuuton.removeAttribute('disabled')
        user.style.display = '';
        guest.style.display = 'none'
        userName.textContent = userData.email
    
    } else {
        addBuuton.setAttribute('disabled', 'true')
        user.style.display = 'none';
        guest.style.display = '';
        userName.textContent = 'guest'
    }

}

async function onLogout(e) {
    e.preventDefault()

    const token = userData.token;
    const url = 'http://localhost:3030/users/logout'

    await fetch(url, {
        method: 'get',
        headers: {
            'X-Authorization': token
        }
    })

    sessionStorage.removeItem('userdata')
    window.location = 'index.html'


}

function onLoad(e) {
    e.preventDefault()

    loadCatches()
}

async function loadCatches() {
    const catchesDiv = document.getElementById('catches');
    catchesDiv.addEventListener('click', onCaches)

    const data = await getCatches()


    let userId
    if (userData){
        userId = userData.id
    
       
    }

    catchesDiv.replaceChildren();
    for (let c of Object.values(data)) {
       const div = document.createElement('div');

       div.innerHTML = `<div class="catch">
                        <label>Angler</label>
                        <input type="text" class="angler" value="${c.angler}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <label>Weight</label>
                        <input type="text" class="weight" value="${c.weight}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <label>Species</label>
                        <input type="text" class="species" value="${c.species}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <label>Location</label>
                        <input type="text" class="location" value="${c.location}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <label>Bait</label>
                        <input type="text" class="bait" value="${c.bait}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <label>Capture Time</label>
                        <input type="number" class="captureTime" value="${c.captureTime}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>
                        <button class="update" data-id="${c._id}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>Update</button>
                        <button class="delete" data-id="${c._id}" ${(userId != c._ownerId) ? 'disabled': 'enabled'}>Delete</button>
                    </div>`

         
           
        
        catchesDiv.appendChild(div)
    }
}


async function getCatches() {
    const url = 'http://localhost:3030/data/catches/'
    try {
        const response = await fetch(url);

        if (response.ok != true) {
            const error = response.json()
            throw new Error(error.message)
        }
        const data = await response.json()
        return data
        
    } catch(error) {
        alert(error.message)
    }
    

}


async function onAdd(e) {
    e.preventDefault()

    const url = 'http://localhost:3030/data/catches'
    const formData = new FormData(e.target)

    const angler = formData.get('angler')
    const weight = formData.get('weight')
    const species = formData.get('species')
    const location = formData.get('location')
    const bait = formData.get('bait')
    const captureTime = formData.get('captureTime')

    if (angler != '' && weight != '' && species != '' && location != '' && bait != '' && captureTime != '') {
        const data = {"angler":angler, "weight":weight, "species":species, "location":location, "bait":bait, "captureTime":captureTime}
    
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.token
            },
    
            body: JSON.stringify(data)
        })
    }
    
    e.target.reset()    
    loadCatches()

}

async function onCaches(e) {
    e.preventDefault()

    const elementClass = e.target.getAttribute('class');
    const id = e.target.getAttribute('data-id');

    if (elementClass == 'delete'){
        const url = 'http://localhost:3030/data/catches/' + id;
    
        await fetch(url, {
            method: 'delete',
            headers: {
                'X-Authorization': userData.token
            }
        })
        e.target.parentNode.remove()

    } else if(elementClass == 'update') {
        const parentElement = e.target.parentElement

        const angler = parentElement.querySelector('.angler')
        const weight = parentElement.querySelector('.weight')
        const species = parentElement.querySelector('.species')
        const location = parentElement.querySelector('.location')
        const bait = parentElement.querySelector('.bait')
        const captureTime = parentElement.querySelector('.captureTime') 

        if (angler != '' && weight.value != '' && species.value != '' && location.value != '' && bait.value != '' && captureTime.value != '') {
            const data = {
                "angler":angler.value, "weight":weight.value, "species":species.value, "location":location.value, "bait":bait.value, "captureTime":captureTime.value
            }
            const url = 'http://localhost:3030/data/catches/' + id;
            try {
                const response = await fetch(url, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userData.token
                },
        
                body: JSON.stringify(data)
            })
            const req = await response.json()
            loadCatches()

            }catch(error) {
                alert(error.message)
            }
        
        }
    }
}
