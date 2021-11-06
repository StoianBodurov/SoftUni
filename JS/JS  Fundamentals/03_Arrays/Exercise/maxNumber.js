function solve(arr) {
  const result = [];

  for (let i = 0; i < arr.length; i++) {
    let isBigger = true;
    for (let j = i + 1; j < arr.length; j++) {
      if (arr[i] <= arr[j]) {
        isBigger = false;
      }
    }
    if (isBigger) {
      result.push(arr[i]);
    }
  }

  console.log(result.join(" "));
}

solve([1, 4, 3, 2]);
solve([14, 24, 3, 19, 15, 17]);
solve([41, 41, 34, 20]);
solve([27, 19, 42, 2, 13, 45, 48]);
