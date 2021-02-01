def read_matrix(size):
    matrix = []
    for _ in range(size):
        row = input().split()
        matrix.append(row)
    return matrix


def get_king_place(matrix):
    for r in range(len(matrix)):
        for c in range(len(matrix[r])):
            if matrix[r][c] == 'K':
                return r, c


def horizontal_quin_place(matrix, king_row, king_column):
    coordinates = []

    for col_i in range(king_column, len(matrix[-1])):
        if matrix[king_row][col_i] == 'Q':
            coordinates.append([king_row, col_i])
            break

    for col_i in range(king_column, -1, -1):
        if matrix[king_row][col_i] == 'Q':
            coordinates.append([king_row, col_i])
            break

    if len(coordinates) > 0:
        return coordinates


def vertical_quin_place(matrix, king_row, king_column):
    coordinates = []

    for row_i in range(king_row, len(matrix)):
        if matrix[row_i][king_column] == 'Q':
            coordinates.append([row_i, king_column])
            break

    for row_i in range(king_row, -1, -1):
        if matrix[row_i][king_column] == 'Q':
            coordinates.append([row_i, king_column])
            break

    if len(coordinates) > 0:
        return coordinates


def primary_diagonally_quin_place(matrix, king_row, king_column):
    coordinates = []

    while True:
        if king_row == 0 or king_column == 0:
            break
        king_row -= 1
        king_column -= 1
        if matrix[king_row][king_column] == 'Q':
            coordinates.append([king_row, king_column])
            break

    while True:
        if king_row == len(matrix) - 1 or king_column == len(matrix) - 1:
            break
        king_row += 1
        king_column += 1
        if matrix[king_row][king_column] == 'Q':
            coordinates.append([king_row, king_column])
            break
    if len(coordinates) > 0:
        return coordinates


def secondary_diagonally_quin_place(matrix, king_row, king_column):
    coordinates = []

    while True:
        if king_row == 0 or king_column == len(matrix) - 1:
            break
        king_row -= 1
        king_column += 1
        if matrix[king_row][king_column] == 'Q':
            coordinates.append([king_row, king_column])
            break

    while True:
        if king_row == len(matrix) - 1 or king_column == 0:
            break
        king_row += 1
        king_column -= 1
        if matrix[king_row][king_column] == 'Q':
            coordinates.append([king_row, king_column])
            break
    if len(coordinates) > 0:
        return coordinates


def find_all_quin(matrix, king_row, king_column):
    quin_coordinates = [horizontal_quin_place(matrix, king_row, king_column),
                        vertical_quin_place(matrix, king_row, king_column),
                        primary_diagonally_quin_place(matrix, king_row, king_column), secondary_diagonally_quin_place(matrix, king_row, king_column)]

    return quin_coordinates


def print_result(result):
    if any(result):
        for r in range(len(result)):
            if result[r] is not None:
                for el in result[r]:
                    print(el)
    else:
        print('The king is safe!')


MATRIX_SIZE = 8
main_matrix = read_matrix(MATRIX_SIZE)
king_r, king_c = get_king_place(main_matrix)
result = find_all_quin(main_matrix, king_r, king_c)
print_result(result)