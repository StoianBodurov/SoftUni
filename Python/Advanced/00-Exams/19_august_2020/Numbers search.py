def numbers_searching(*args):
    min_el = min(args)
    max_el = max(args)
    duplicates = []
    missing_value = min_el

    for i in range(min_el, max_el + 1):
        count = 0
        for el in args:
            if el == i:
                count += 1
        if count > 1:
            duplicates.append(i)
        elif count == 0:
            missing_value = i

    return [missing_value, sorted(duplicates)]


print(numbers_searching(1, 2, 4, 2, 5, 4))
print(numbers_searching(5, 5, 9, 10, 7, 8, 7, 9))
print(numbers_searching(50, 50, 47, 47, 48, 45, 49, 44, 47, 45, 44, 44, 48, 44, 48))
