function sortFunction(array, order) {
  if (order == "asc") {
    return array.sort((a, b) => a - b);
  } else if (order == "desc") {
    return array.sort((a, b) => b - a);
  }
}

console.log(sortFunction([14, 7, 17, 6, 8], "asc"));
console.log(sortFunction([14, 7, 17, 6, 8], 'desc'))