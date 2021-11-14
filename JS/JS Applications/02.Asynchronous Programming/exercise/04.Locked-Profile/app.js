async function lockedProfile() {
    const main = document.getElementById('main');
    main.innerHTML = '';

    const data = await getData();

    for (let [id, profile] of Object.entries(data)) {
        main.appendChild(createProfile(profile));
    }

    main.addEventListener('click', showFunction);

    function showFunction(event) {
        if (event.target.tagName == 'BUTTON') {
                const profile = event.target.parentElement
            const lockInput = profile.querySelector('[value = "lock"')
            if (!lockInput.checked) {
                const hiddenFields = profile.querySelector('#user1HiddenFields')
                const button = profile.querySelector('button')
            

                if (hiddenFields.style.display == 'none') {
    
                    hiddenFields.style.display = 'block'
                    button.textContent = 'Hide it'
    
                } else {
    
                    hiddenFields.style.display = 'none'
                    button.textContent = 'Show more'
    
                }

            }
            
            
        }
    }

}

async function getData() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles'

    const response = await fetch(url);
    const data = await response.json();

    return data
}


function createProfile(profile) {

    const divProfile = document.createElement('div');
    divProfile.classList.add('profile');

    const img = document.createElement('img');
    img.classList.add('userIcon');
    img.setAttribute('src', './iconProfile2.png')
    divProfile.appendChild(img);

    const labelLock = document.createElement('label');
    labelLock.textContent = 'Lock';
    divProfile.appendChild(labelLock);

    const inputlock = document.createElement('input');
    inputlock.setAttribute('type', 'radio');
    inputlock.setAttribute('name', `user${profile._id}Locked`);
    inputlock.setAttribute('checked', 'true')
    inputlock.setAttribute('value', 'lock');
    divProfile.appendChild(inputlock);


    
    const labelUnlock = document.createElement('label');
    labelUnlock.textContent = 'Unlock';
    divProfile.appendChild(labelUnlock);

    const inputUnlock = document.createElement('input');
    inputUnlock.setAttribute('type', 'radio');
    inputUnlock.setAttribute('name', `user${profile._id}Locked`);

    inputUnlock.setAttribute('value', 'unlock');
    divProfile.appendChild(inputUnlock);

    divProfile.appendChild(document.createElement('br'));
    divProfile.appendChild(document.createElement('hr'));

    const labelUserName = document.createElement('label');
    labelUserName.textContent = 'Username';
    divProfile.appendChild(labelUserName);

    const inputUserName = document.createElement('input');
    inputUserName.setAttribute('type', 'text');
    inputUserName.setAttribute('name', 'user1Username');
    inputUserName.setAttribute('readonly', true);
    inputUserName.setAttribute('disabled', true);
    inputUserName.value = profile.username;
    divProfile.appendChild(inputUserName);


    const hiddenDiv = document.createElement('div');
    hiddenDiv.setAttribute('id', 'user1HiddenFields');
    divProfile.appendChild(hiddenDiv);

    hiddenDiv.appendChild(document.createElement('hr'));

    const labelEmail = document.createElement('label');
    labelEmail.textContent = 'Email';
    hiddenDiv.appendChild(labelEmail);

    const inputEmail = document.createElement('input');
    inputEmail.setAttribute('type', 'email');
    inputEmail.setAttribute('name', 'user1Email');
    inputEmail.setAttribute('readonly', true);
    inputEmail.setAttribute('disabled', true);
    inputEmail.value = profile.email
    hiddenDiv.appendChild(inputEmail)

    const labelAge = document.createElement('label');
    labelAge.textContent = 'Age';
    hiddenDiv.appendChild(labelAge);

    const inputAge = document.createElement('input');
    inputAge.setAttribute('type', 'email');
    inputAge.setAttribute('name', 'user1Age');
    inputAge.setAttribute('readonly', true);
    inputAge.setAttribute('disabled', true);
    inputAge.value = profile.age;
    hiddenDiv.appendChild(inputAge);

    const showButton = document.createElement('button');
    showButton.textContent = 'Show more';
    divProfile.appendChild(showButton)

    return divProfile

}
