// const { assert } = require("chai");
// const { createCalculator } = require("./addSubtract");

// describe("sumator", () => {
//   let calculator = null;

//   beforeEach(() => {
//     calculator = createCalculator();
//   });

//   describe("test CreateCalculator created object", () => {
//     const calculator = createCalculator();
//     it("It calculator is object", () => {
//       assert.isObject(calculator);
//     });
//     it("Check from corect properties", () => {
//       assert.hasAllKeys(calculator, ["add", "subtract", "get"]);
//     });
//   });

//   describe("test CreateCalculator whit number value", () => {
//     it("Add function whit corect value", () => {
//       calculator.add(2);
//       assert.equal(calculator.get(), 2);
//     });
//     it("subtract function whit corect value", () => {
//       calculator.subtract(4);
//       assert.equal(calculator.get(), -4);
//     });
//   });

//   describe("test CreateCalculator whit atring value", () => {
//     it("Add function whit corect value", () => {
//       calculator.add("2");
//       assert.equal(calculator.get(), 2);
//     });
//     it("subtract function whit corect value", () => {
//       calculator.subtract("4");
//       assert.equal(calculator.get(), -4);
//     });
//   });
// });
