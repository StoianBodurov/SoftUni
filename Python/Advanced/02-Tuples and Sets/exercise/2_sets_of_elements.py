first_set_lenght, second_set_lenght = [int(el) for el in input().split()]

first_set = set()
second_set = set()

for _ in range(first_set_lenght):
    first_set.add(input())

for _ in range(second_set_lenght):
    second_set.add(input())

result = first_set & second_set

print(*result, sep='\n')