from itertools import permutations


def possible_permutations(obj):
    perm = permutations(obj)
    for el in perm:
        yield list(el)


[print(n) for n in possible_permutations([1, 2, 3])]

