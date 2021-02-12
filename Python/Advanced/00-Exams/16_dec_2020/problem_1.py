from collections import deque

males = [int(el) for el in input().split(' ')]
females = deque([int(el) for el in input().split(' ')])

matches = 0

while len(males) > 0 and len(females) > 0:
    males_value = males.pop()
    females_value = females.popleft()
    if males_value <= 0:
        females.appendleft(females_value)
        continue

    if females_value <= 0:
        males.append(males_value)
        continue

    if males_value % 25 == 0:
        females.appendleft(females_value)
        males.pop()
        continue

    if females_value % 25 == 0:
        males.append(males_value)
        females.popleft()
        continue

    if not males_value == females_value:
        males.append(males_value - 2)
    else:
        matches += 1

print(f'Matches: {matches}')

if males:
    sorted_males = sorted((-i, v) for i,v in enumerate(males))
    print(f"Males left: {', '.join(str(v) for i, v in sorted_males)}")
else:
    print(f'Males left: none')

if females:
    print(f"Females left: {', '.join(str(el) for el in females)}")
else:
    print(f'Females left: none')
