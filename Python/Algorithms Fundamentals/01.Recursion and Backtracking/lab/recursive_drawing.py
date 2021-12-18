n = int(input())


def draw(n):
    if n == 0:
        return

    for i in range(n):
        print('* ', end='')
    print()

    draw(n - 1)

    for i in range(n):
        print('# ', end='')
    print()


draw(n)
