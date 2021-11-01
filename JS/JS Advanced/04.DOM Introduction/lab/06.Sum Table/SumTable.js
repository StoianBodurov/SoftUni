function sumTable() {
    let rows = document.querySelectorAll('table tr')
    let sum = 0

    for (let i = 1; i < rows.length; i++) {
        let col = rows[i].children;
        sum += Number(col[col.length - 1].textContent);

    }
    document.getElementById('sum').textContent = sum;

}