import sys


def read_matrix():
    rows, columns = [int(el) for el in input().split(' ')]
    matrix = []
    for _ in range(rows):
        row = [int(e) for e in input().split(' ')]
        matrix.append(row)
    return matrix


def get_sub_matrix(row_index, col_index, matrix, size):
    sub_mat = []

    for row in range(row_index, row_index + size):
        matrix_row = []
        for col in range(col_index, col_index + size):
            matrix_row.append(matrix[row][col])
        sub_mat.append(matrix_row)
    return sub_mat


def is_valid_indexes(matrix, row_i, column_i):
    return 0 <= row_i < len(matrix) and 0 <= column_i <len(matrix[0])


sub_matrix_el_pos = ((0, 1), (0, 2), (1, 0), (1, 1), (1, 2), (2, 0), (2, 1), (2, 2))


matrix = read_matrix()
SUB_MATRIX_SIZE = 3
maximal_sum = - sys.maxsize - 1
sub_matrix_row_index = 0
sub_matrix_col_index = 0

for row_index in range(len(matrix) - SUB_MATRIX_SIZE + 1):
    for col_index in range(len(matrix[row_index]) - SUB_MATRIX_SIZE + 1):
        el_sum = matrix[row_index][col_index]
        for r, c in sub_matrix_el_pos:
            check_row = row_index + r
            check_column = col_index + c
            if is_valid_indexes(matrix, check_row, check_column):
                el_sum += matrix[check_row][check_column]
            else:
                break
        if el_sum > maximal_sum:
            maximal_sum = el_sum
            sub_matrix_row_index = row_index
            sub_matrix_col_index = col_index
        # for r in range(row_index, row_index + SUB_MATRIX_SIZE):
        #     for c in range(col_index, col_index + SUB_MATRIX_SIZE):
        #         el_sum += matrix[r][c]
        #
        # if el_sum > maximal_sum:
        #     maximal_sum = el_sum
        #     sub_matrix_row_index = row_index
        #     sub_matrix_col_index = col_index

if len(matrix) >= SUB_MATRIX_SIZE and len(matrix[-1]) >= SUB_MATRIX_SIZE:
    sub_matrix = get_sub_matrix(sub_matrix_row_index, sub_matrix_col_index, matrix, SUB_MATRIX_SIZE)

    print(f'Sum = {maximal_sum}')

    for el in sub_matrix:
        print(' '.join([str(e) for e in el]))
