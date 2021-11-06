function solve(arr) {
  let isResult = true;

  for (let i = 0; i < arr.length; i++) {
    let leftSum = 0;
    let rightSum = 0;

    for (let j = 0; j < i; j++) {
      leftSum += arr[j];
    }
    for (let x = i + 1; x < arr.length; x++) {
      rightSum += arr[x];
    }

    if (leftSum == rightSum) {
      isResult = false;
      console.log(i);
      break;
    }
  }

  if (isResult) {
    console.log("no");
  }
}

solve([1, 2, 3, 3]);
solve([1]);
solve([1, 2]);
solve([1, 2, 3]);
solve([10, 5, 5, 99, 3, 4, 2, 5, 1, 1, 4]);
