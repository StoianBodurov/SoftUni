factor = int(input())
count = int(input())
list = []

for i in range(factor, factor * count + 1, factor):
    list.append(i)
print(list)
