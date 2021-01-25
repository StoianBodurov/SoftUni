def read_matrix():
    rows, columns = [int(el) for el in input().split(' ')]
    matrix = []
    for _ in range(rows):
        row = input().split(' ')
        matrix.append(row)
    return matrix


count = 0
SUB_MATRIX_SIZE = 2
matrix = read_matrix()

for row_index in range(len(matrix) - SUB_MATRIX_SIZE + 1):
    for col_index in range(len(matrix[row_index]) - SUB_MATRIX_SIZE + 1):
        sub_matrix_elements = set()
        for r in range(row_index, row_index + SUB_MATRIX_SIZE):
            for c in range(col_index, col_index + SUB_MATRIX_SIZE):
                sub_matrix_elements.add(matrix[r][c])

        if len(sub_matrix_elements) == 1:
            count += 1


print(count)