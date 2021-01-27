from collections import defaultdict

n = int(input())

result = defaultdict(list)

for _ in range(n):
    student, grade = input().split(' ')
    result[student].append(float(grade))

for k, v in result.items():
    print(f"{k} -> {' '.join([str(format(el, '.2f')) for el in v])} (avg: {sum(v) / len(v):.2f})")