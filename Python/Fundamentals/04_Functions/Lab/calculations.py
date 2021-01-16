input_operator = input()
first_num = int(input())
second_num = int(input())


def calculate(operator, a, b):
    result = 0
    if operator == 'multiply':
        result = a * b
    elif operator == 'divide':
        result = a // b
    elif operator == 'add':
        result = a + b
    elif operator == 'subtract':
        result = a - b

    return result


print(calculate(input_operator, first_num, second_num))
