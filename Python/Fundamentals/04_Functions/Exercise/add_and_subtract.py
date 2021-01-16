num1 = int(input())
num2 = int(input())
num3 = int(input())


def sum_numbers(a, b):
    result = a + b
    return result


def subtract(a, b) -> object:
    result = a - b
    return result


def add_and_subtract(a, b, c):
    # sum = sum_numbers(a, b)
    sub = subtract(sum_numbers(a, b), c)
    return sub


print(add_and_subtract(num1, num2, num3))
