function solve(...data) {
  const result = {};

  const forSorted = [];

  for (let el of data) {
    if (!Object.keys(result).includes(typeof el)) {
      result[typeof el] = [];
    }
    result[typeof el].push(el);
  }
  for (let [key, value] of Object.entries(result)) {
    for (let i = 0; i < result[key].length; i++) {
      console.log(`${key}: ${result[key][i]}`);
    }
    forSorted.push([key, value]);
  }

  for (let el of forSorted.sort((a, b) => b[1].length - a[1].length)) {
    console.log(`${el[0]} = ${el[1].length}`);
  }
}

solve({ name: "bob" }, 3.333, 9.999);
