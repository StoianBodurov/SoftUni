function fibonacci() {
  const result = [0, 1];

  function fibo() {
    result.push(result[result.length - 2] + result[result.length - 1]);
    return result[result.length - 2];
  }

  return fibo;
}

let f = fibonacci();
console.log(f());
console.log(f());
console.log(f());
console.log(f());
console.log(f());
console.log(f());
console.log(f());
