function solve(area, vol, input) {
  const data = JSON.parse(input);
  const result = [];

  for (let d of data) {
    result.push({ area: area.call(d), volume: vol.call(d) });
  }

  return result;
}

function area() {
  return Math.abs(this.x * this.y);
}

function vol() {
  return Math.abs(this.x * this.y * this.z);
}

const input = `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
]`;

console.log(solve(area, vol, input));
