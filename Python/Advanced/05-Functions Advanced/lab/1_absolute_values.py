def return_absolute_value(numbers):
    return [abs(num) for num in numbers]


numbers = [float(el) for el in input().split(' ')]
print(return_absolute_value(numbers))