function attachGradientEvents() {
    const hoverboard = document.getElementById('gradient')
    const result = document.getElementById('result')
   

    hoverboard.addEventListener('mousemove', getGradient)
    hoverboard.addEventListener('mouseout', () => result.textContent = '')

    function getGradient(event){

        let gradient = Math.trunc((event.offsetX / (event.target.clientWidth) * 100))
        result.textContent = `${gradient}%`
    }
}