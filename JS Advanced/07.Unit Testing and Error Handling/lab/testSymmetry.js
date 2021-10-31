// const {isSymmetric} = require('./symmetry')
// const {assert} = require('chai')

// describe('testIsSymmetric', () => {
//     it('Input is number', () => {
//         assert.isFalse(isSymmetric(2));
//     });
//     it('Input is string', () => {
//         assert.isFalse(isSymmetric('aba'));
//     });
//     it('Input is object', () => {
//         assert.isFalse(isSymmetric({}));
//     });
//     it('Input is boolean', () => {
//         assert.isFalse(isSymmetric(false));
//     });
//     it('Corect input and is symmetryc and array elemets is string', () => {
//         assert.isTrue(isSymmetric(['a', 'b', 'a']));
//     });
//     it('Corect input and not a simmetryc and array elements is string', () => {
//         assert.isFalse(isSymmetric(['a', 'b']));
//     });
//         it('Corect input and is symmetryc and array elements is number', () => {
//         assert.isTrue(isSymmetric([1, 2, 1]));
//     });
//         it('Corect input and not a simmetryc and array elements is number', () => {
//         assert.isFalse(isSymmetric([1, 2]));
//     });
// })