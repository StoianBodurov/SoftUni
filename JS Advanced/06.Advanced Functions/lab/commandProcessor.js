function solve() {
  let inputString = "";

  function append(str) {
    inputString += str;
  }

  function removeStart(n) {
    inputString = inputString.slice(n);
  }

  function removeEnd(n) {
    inputString = inputString.slice(0, -n);
  }

  function print() {
    console.log(inputString);
  }

  return { append, removeStart, removeEnd, print };
}

let firstZeroTest = solve();

firstZeroTest.append("hello");
firstZeroTest.append("again");
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
