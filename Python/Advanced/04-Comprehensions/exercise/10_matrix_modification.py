def read_matrix(n):
    return [[int(el) for el in input().split(' ')] for _ in range(n)]


def validate_coordinates(matrix, r, c):
    if 0 <= r < len(matrix) and 0 <= c < len(matrix[r]):
        return True
    return False


def print_result(matrix):
    return [print(*el) for el in matrix]


n = int(input())
main_matrix = read_matrix(n)

while True:
    commands = input()
    if commands == 'END':
        break

    command, row, col, value = commands.split()
    row = int(row)
    col = int(col)
    value = int(value)
    if validate_coordinates(main_matrix, row, col):
        if command == 'Add':
            main_matrix[row][col] += value
        else:
            main_matrix[row][col] -= value
    else:
        print('Invalid coordinates')

print_result(main_matrix)
