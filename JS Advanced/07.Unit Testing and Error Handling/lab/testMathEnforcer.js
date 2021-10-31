const {assert, expect} = require('chai')
const {mathEnforcer} = require('./mathEnforcer')

describe('mathEnforcer', () => {
    describe('Test adFive', () => {
        it ('If value not a number return undifined', () => {
            assert.isUndefined(mathEnforcer.addFive('dfd'));
        });
        it ('If value is number type return corct result', () => {
            expect(mathEnforcer.addFive(5.05)).to.closeTo(10.05, 0.01);
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });
    });
    describe('Test subtractTen', () => {
        it ('If value not a number return undifined', ()=> {
            assert.isUndefined(mathEnforcer.subtractTen('25'));
        });
        it ('If value is number type return corct result', () => {
            expect(mathEnforcer.subtractTen(-15)).to.equal(-25);
            expect(mathEnforcer.subtractTen(5.05)).to.closeTo(-4.95, 0.01);
            
        });
    });
     describe('Test sum', () => {
        it ('If firs value not a number return undifined', ()=> {
            assert.isUndefined(mathEnforcer.sum('25', 5));
            assert.isUndefined(mathEnforcer.sum([], 5));
            assert.isUndefined(mathEnforcer.sum({}, 5));
        });
        it ('If second value not a number return undifined', ()=> {
            assert.isUndefined(mathEnforcer.sum(25, '5'));
            assert.isUndefined(mathEnforcer.sum(25, []));
            assert.isUndefined(mathEnforcer.sum(25, {}));
        });
        it ('If value is number type return corct result', () => {
            expect(mathEnforcer.sum(-15, 10)).to.equal(-5);
            expect(mathEnforcer.sum(5.05, 10)).to.closeTo(15.05, 0.01);

        });
    });
})