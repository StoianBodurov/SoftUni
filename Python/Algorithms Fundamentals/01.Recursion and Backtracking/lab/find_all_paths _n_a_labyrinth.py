def is_in_bounds(row, col, matrix):
    return 0 <= row < len(matrix) and 0 <= col < len(matrix[0])


def is_exit(row, col, matrix):
    return matrix[row][col] == 'e'


def is_visited(row, col, matrix):
    return matrix[row][col] == 'v'


def is_free(row, col, matrix):
    return matrix[row][col] == '-'


def find_paths(row, col, matrix, path, direction):

    if not is_in_bounds(row, col, matrix):
        return

    path.append(direction)

    if is_exit(row, col, matrix):
        print(''.join(path[1::]))
    elif not is_visited(row, col, matrix) and is_free(row, col, matrix):
        matrix[row][col] = 'v'
        find_paths(row, col + 1, matrix, path, 'R')
        find_paths(row + 1, col, matrix, path, 'D')
        find_paths(row, col - 1, matrix, path, 'L')
        find_paths(row - 1, col, matrix, path, 'U')
        matrix[row][col] = '-'

    path.pop()


row = int(input())
col = int(input())

matrix = []
path = []

for i in range(0, row):
    r = list(input())
    matrix.append(r)


find_paths(0, 0, matrix, path, 'S')

