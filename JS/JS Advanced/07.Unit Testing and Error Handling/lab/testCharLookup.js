// const {assert , expect} = require('chai')
// const {lookupChar} = require('./charLookup')


// describe('Test charLookup', () => {
//     it('Test when first parameter not a string expect undefined', () => {
//         assert.isUndefined(lookupChar([25, 'l'], 1));
//     });
//     it('Test when first parameter not a string second marameter not a number expect undefined', () => {
//         assert.isUndefined(lookupChar([25, 'l'], '1'));
//     });
//     it ('Test when second parameter not a number expect undefined', () => {
//         assert.isUndefined(lookupChar('asdfsdgs', '2'));
//     });
//     it ('Test when boot parameters is whit corect type index < 0', () => {
//         assert.equal(lookupChar('sdad', -1), 'Incorrect index')
//     });
//     it ('Test when boot parameters is whit corect type index bigeger than length of string', () => {
//         assert.equal(lookupChar('sdad', 5), 'Incorrect index');
//     });
//     it ('Test when boot parameters is whit corect type index equal than length of string', () => {
//         assert.equal(lookupChar('sdad', 4), 'Incorrect index');
//     });
//     it ('Test whit corect data return the character at the specified index 0 in the string', () => {
//         assert.equal(lookupChar('aswedc', 0), 'a')
//     });
//     it ('Test whit corect data return the character at the specified last index in the string', () => {
//         assert.equal(lookupChar('aswedc', 5), 'c')
//     });

// })
