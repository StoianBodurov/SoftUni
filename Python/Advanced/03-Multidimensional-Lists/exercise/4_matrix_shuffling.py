def read_matrix():
    rows, columns = [int(el) for el in input().split(' ')]
    matrix = []
    for _ in range(rows):
        row = [e for e in input().split(' ')]
        matrix.append(row)
    return matrix


def index_is_valid(matrix, r1, c1, r2, c2):
    if 0 <= r1 < len(matrix) and 0 <= r2 < len(matrix) and 0 <= c1 < len(matrix[r1]) and 0 <= c1 < len(matrix[r2]):
        return True
    return False


def print_matrix(matrix):
    for i in range(len(main_matrix)):
        print(' '.join([str(el) for el in matrix[i]]))


main_matrix = read_matrix()
while True:
    commands = input()
    if commands == 'END':
        break
    command, *res = commands.split(' ')
    if command == 'swap':
        row1, col1, row2, col2 = [int(el) for el in res]
        if index_is_valid(main_matrix, row1,col1, row2, col2):
            main_matrix[row1][col1], main_matrix[row2][col2] = main_matrix[row2][col2], main_matrix[row1][col1]
            print_matrix(main_matrix)
        else:
            print('Invalid input!')
    else:
        print('Invalid input!')


