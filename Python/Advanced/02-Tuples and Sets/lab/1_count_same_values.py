from collections import defaultdict

data = tuple(map(float, input().split(' ')))

result = defaultdict(int)

for el in data:
    result[el] += 1

for k, v in result.items():
    print(f'{k} - {v} times')