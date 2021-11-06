function solve(arr) {
  const result = [];

  for (let i = 0; i < arr.length; i++) {
    const equalNumber = [arr[i]];

    for (let j = i + 1; j < arr.length; j++) {
      if (arr[i] == arr[j]) {
        equalNumber.push(arr[i]);
      } else {
        break;
      }
    }
    result.push(equalNumber);
  }

  let maxSequence = result[0];
  for (let i = 1; i < result.length; i++) {
    if (maxSequence.length < result[i].length) {
      maxSequence = result[i];
    }
  }

  console.log(maxSequence.join(" "));
}

solve([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
solve([1, 1, 1, 2, 3, 1, 3, 3]);
solve([4, 4, 4, 4]);
solve([0, 1, 1, 5, 2, 2, 6, 3, 3]);
