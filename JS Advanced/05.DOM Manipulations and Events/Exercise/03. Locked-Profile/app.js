function lockedProfile() {
    const el = document.querySelectorAll('.profile button')
    
    for (let e of el){
        e.addEventListener('click', unlockLock);
    

        function unlockLock(ev) {
            const profile = ev.target.parentElement
            const radio_checked = profile.querySelector('input[type="radio"][value="unlock"]').checked;


            if (radio_checked) {
                const div = profile.querySelector('div')
                if (ev.target.textContent == 'Show more') {
                    div.style.display = 'block';
                    e.textContent = 'Hide it';
                } else  {
                    div.style.display = ''
                    e.textContent = 'Show more'
                }
            }
        }
         
    }
}