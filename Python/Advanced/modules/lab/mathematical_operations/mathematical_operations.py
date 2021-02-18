from .basic_calculations import multiply, divide, add, subtract, power


def calculate(data):
    num1, operation, num2 = data.split(' ')
    num1 = float(num1)
    num2 = int(num2)
    result = None
    if operation == '*':
        result = multiply(num1, num2)
    if operation == '/':
        result = divide(num1, num2)
    if operation == '+':
        result = add(num1, num2)
    if operation == '-':
        result = subtract(num1, num2)
    if operation == '^':
        result = power(num1, num2)

    print(f'{result:.2f}')