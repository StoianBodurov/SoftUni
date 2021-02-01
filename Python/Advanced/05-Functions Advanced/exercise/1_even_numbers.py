data = [int(el) for el in input().split()]
even_nums = list(filter(lambda x: x % 2 == 0, data))
print(even_nums)