def read_matrix():
    rows, columns = [int(el) for el in input().split(' ')]
    matrix = []
    for _ in range(rows):
        row = input().split(' ')
        matrix.append(row)
    return matrix


def chek_elements_ar_equal(matr, r, c):
    sub_matrix = []
    for r in range(row_index, row_index + SUB_MATRIX_SIZE):
        for c in range(col_index, col_index + SUB_MATRIX_SIZE):
            current_element = matrix[r][c]
            sub_matrix.append(current_element)
    if sub_matrix[0] ==sub_matrix[1] and sub_matrix[1] == sub_matrix[2] and sub_matrix[2] == sub_matrix[3]:
        return True
    return False


count = 0
SUB_MATRIX_SIZE = 2
matrix = read_matrix()

for row_index in range(len(matrix) - SUB_MATRIX_SIZE + 1):
    for col_index in range(len(matrix[row_index]) - SUB_MATRIX_SIZE + 1):
        if chek_elements_ar_equal(matrix, row_index, col_index):
            count += 1


print(count)