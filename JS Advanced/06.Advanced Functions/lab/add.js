function solution(n) {
  function add(a) {
    return a + n;
  }
  return add;
}

let add5 = solution(5);

console.log(add5(3));
