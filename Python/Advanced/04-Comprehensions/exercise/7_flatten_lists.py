data = input().split('|')

print(*[el for i in range(len(data) -1, -1, -1) for el in data[i].split()])
