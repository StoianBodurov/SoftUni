n = int(input())

for digit in range(1, n + 1):
    num = str(digit)
    sum = 0
    for i in num:
        sum += int(i)
    print(sum)
    valid = sum == 5 or sum == 7 or sum ==11
    print(f'{digit} -> {valid}')