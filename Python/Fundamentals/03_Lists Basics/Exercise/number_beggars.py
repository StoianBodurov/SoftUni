nums_str = input().split(', ')
number_beggar = int(input())
index = 0

numbers = []
beggers = []

for num in nums_str:
    numbers.append(int(num))

for i in range(number_beggar):
    beggers.append(0)

for num in numbers:
    beggers[index] += num
    index += 1
    if index == number_beggar:
        index = 0

print(beggers)