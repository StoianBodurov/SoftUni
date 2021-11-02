function solve(n){
    let centuries = n;
    let yeares = centuries * 100;
    let days = Math.trunc(yeares * 365.2422);
    let hours = days * 24
    let minutes = hours * 60
    console.log(`${centuries} centuries = ${yeares} years = ${days} days = ${hours} hours = ${minutes} minutes`)
}

solve(1)