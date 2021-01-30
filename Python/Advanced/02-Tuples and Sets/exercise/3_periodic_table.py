n = int(input())

chemical_elements = set()

for _ in range(n):
    data = input().split(' ')
    [chemical_elements.add(el) for el in data]
    # for el in data:
    #     chemical_elements.add(el)

print(*chemical_elements, sep = '\n')