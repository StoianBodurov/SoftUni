num1 = int(input())
num2 = int(input())


def factorial(num):
    result = 1
    for i in range(1, num + 1):
        result *= i
    return result


print(f'{factorial(num1) / factorial(num2):.2f}')