from functools import reduce


def operate(operator, *args):
    operators = {
        '+': lambda x, y: x + y,
        '-': lambda x, y: x - y,
        '*': lambda x, y: x * y,
        '/': lambda x, y: x / y,
    }
    return reduce(operators[operator], args)


print(operate("+", 1, 2, 3))
print(operate("*", 3, 4))
