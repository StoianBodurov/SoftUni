def print_row(size, star_count):
    spaces = ' ' * (size - star_count)
    stars = ('* ' * star_count).strip()
    print(spaces + stars)


def rhombus_of_star(n):
    for i in range(1, n + 1):
        print_row(n, i)
    for i in range(n - 1, -1, -1):
        print_row(n, i)


rhombus_of_star(int(input()))