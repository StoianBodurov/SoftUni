n = int(input())


def get_factorial(n):
    if n <= 1:
        return 1

    return get_factorial(n - 1) * n


print(get_factorial(n))