number = int(input())

sum = 0

while number > 0:
    letter = input()
    sum += ord(letter)
    number -= 1

print(f'The sum equals: {sum}')
