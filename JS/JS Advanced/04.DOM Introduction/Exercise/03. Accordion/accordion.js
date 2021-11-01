function toggle() {
    const extra = document.getElementById('extra');
    const less = document.getElementsByClassName('button')[0];

    if (less.textContent === 'Less') {
        extra.style.display = 'none';
        less.textContent = 'More';

    } else {
        extra.style.display = 'block';
        less.textContent = 'Less';
    }
}