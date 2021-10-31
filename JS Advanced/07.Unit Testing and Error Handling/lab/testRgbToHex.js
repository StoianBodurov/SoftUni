// const {assert} = require('chai')
// const {rgbToHexColor} = require('./RgbToHex')


// describe('Test rgbToHexcolor', () => {
//         it('Ivalid red is string', () => {
//         assert.isUndefined(rgbToHexColor('255', 255, 255));
//     });
//         it('Ivalid red is smaller of 0', () => {
//         assert.isUndefined(rgbToHexColor(-1, 255, 255));
//     });
//         it('Ivalid red is bigger of 255', () => {
//         assert.isUndefined(rgbToHexColor(256, 255, 255));
//     });
//         it('Ivalid green is string', () => {
//         assert.isUndefined(rgbToHexColor(255, '255', 255));
//     });
//         it('Ivalid green is smaller of 0', () => {
//         assert.isUndefined(rgbToHexColor(255, -1, 255));
//     });
//         it('Ivalid green is bigger of 255', () => {
//         assert.isUndefined(rgbToHexColor(255, 256, 255));
//     });
//         it('Ivalid blue is string', () => {
//         assert.isUndefined(rgbToHexColor(255, 255, '255'));
//     });
//         it('Ivalid blue is smaller of 0', () => {
//         assert.isUndefined(rgbToHexColor(255, 255, -1));
//     });
//         it('Ivalid blue is bigger of 255', () => {
//         assert.isUndefined(rgbToHexColor(255, 255, 256));
//     });
//         it('Mas by corect value', () => {
//             assert.equal(rgbToHexColor(255, 52, 52), '#FF3434');
//     });
//         it('Black value', () => {
//             assert.equal(rgbToHexColor(0, 0, 0), '#000000');
//     });
//       it('White value', () => {
//             assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF');
//     });
// })