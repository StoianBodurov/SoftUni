function solve(width, height, color) {
    let colorToUpper = color[0].toUpperCase() + color.slice(1)
    const reactangle = {
        width,
        height,
        color: colorToUpper,
        calcArea() { return height * width}
    }

    return reactangle
}

let rect = solve(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());