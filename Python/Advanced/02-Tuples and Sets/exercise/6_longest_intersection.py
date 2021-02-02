n = int(input())

longest_intersection = set()

for _ in range(n):
    first, second = input().split('-')
    first_start, first_end = [int(el) for el in first.split(',')]
    second_start, second_end = [int(el) for el in second.split(',')]
    set_1 = set()
    set_2 = set()

    for el in range(first_start, first_end + 1):
        set_1.add(el)

    for el in range(second_start, second_end + 1):
        set_2.add(el)

    result = set_1 & set_2
    if len(result) > len(longest_intersection):
        longest_intersection = result

print(f"Longest intersection is {[el for el in longest_intersection]} with length {len(longest_intersection)}")