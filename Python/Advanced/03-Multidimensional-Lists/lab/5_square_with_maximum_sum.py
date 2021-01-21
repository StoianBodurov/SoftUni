def get_matrix(matrix_rows):
    matrix = []
    for _ in range(matrix_rows):
        row = list(map(int, input().split(', ')))
        matrix.append(row)

    return matrix


rows, columns = map(int, input().split(', '))
main_matrix = get_matrix(rows)
SUB_MATRIX_SIZE = 2

sub_matrix = []
sub_matrix_sum = 0
sub_matrix_row_index = 0
sub_matrix_col_index = 0


for row_index in range(len(main_matrix) - SUB_MATRIX_SIZE + 1):
    for col_index in range(len(main_matrix[row_index]) - SUB_MATRIX_SIZE + 1):
        current_sum = 0
        for r in range(row_index, row_index + 2):
            for c in range(col_index, col_index + 2):
                current_sum += main_matrix[r][c]

        if current_sum > sub_matrix_sum:
            sub_matrix_sum = current_sum
            sub_matrix_row_index = row_index
            sub_matrix_col_index = col_index


for r in range(sub_matrix_row_index, sub_matrix_row_index + SUB_MATRIX_SIZE):
    sub_matrix_row =[]
    for c in range(sub_matrix_col_index, sub_matrix_col_index + SUB_MATRIX_SIZE):
        sub_matrix_row.append(main_matrix[r][c])
    sub_matrix.append(sub_matrix_row)


for el in sub_matrix:
    print(' '.join([str(e) for e in el]))

print(sub_matrix_sum)


