function colorize() {
    let rows = document.querySelectorAll('table tr');
    console.log(rows.length)

    for (let i = 1; i < rows.length; i += 2) {
        let row = rows[i];
        console.log(row)
        row.style.background = 'teal';


    }
}