def get_matrix(row, column):
    matrix = []
    for _ in range(row):
        line = list(map(int, input().split(' ')))
        matrix.append(line)
    return matrix


def sum_matrix_columns(matrix):
    sum_columns = []
    for col_index in range(len(matrix[0])):
        sum_column = 0
        for row_index in range(len(matrix)):
            sum_column += matrix[row_index][col_index]

        sum_columns.append(sum_column)
    return sum_columns


def print_result(sum_matrix):
    print('\n'.join(map(str, sum_matrix)))


rows, columns = map(int, input().split(', '))
main_matrix = get_matrix(rows, columns)
main_matrix_columns_sum = sum_matrix_columns(main_matrix)
result = print_result(main_matrix_columns_sum)
