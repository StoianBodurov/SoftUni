import math


class Integer:
    ROMAN_DIGITS = {
        'I': 1,
        'V': 5,
        'X': 10,
        'L': 50,
        'C': 100,
        'D': 500,
        'M': 1000,
        'IV': 4,
        'IX': 9,
        'XL': 40,
        'XC': 90,
        'CD': 400,
        'CM': 900
    }

    def __init__(self, value):
        self.value = value

    @classmethod
    def from_float(cls, value):
        if type(value) != float:
            return 'value is not a float'
        return cls(math.trunc(value))

    @classmethod
    def from_roman(cls, value):
        i = 0
        num = 0
        while i < len(value):
            if i + 1 < len(value) and value[i:i + 2] in cls.ROMAN_DIGITS:
                num += cls.ROMAN_DIGITS[value[i:i + 2]]
                i += 2
            else:
                num += cls.ROMAN_DIGITS[value[i]]
                i += 1

        return cls(num)

    @classmethod
    def	from_string(cls, value):
        if type(value) != str:
            return 'wrong type'
        return cls(math.trunc(float(value)))

    def add(self, integer):
        if type(integer) != Integer:
            return 'number should be an Integer instance'

        return self.value + integer.value


first_num = Integer(10)
second_num = Integer.from_roman("IV")

print(Integer.from_float("2.6"))
print(Integer.from_string(2.6))
print(first_num.add(second_num))
