numbers = input().split(' ')

reversed_numbers = []

while numbers:
    reversed_numbers.append(numbers.pop())

print(' '.join(reversed_numbers))