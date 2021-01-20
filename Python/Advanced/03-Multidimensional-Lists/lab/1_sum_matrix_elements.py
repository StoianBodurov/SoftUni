def get_matrix(row, col):
    matrix = []
    for _ in range(row):
        line = list(map(int, input().split(', ')))
        matrix.append(line)
    return matrix


def get_sum_matrix(m):
    sum_m = 0
    for row in range(rows):
        for column in range(columns):
            sum_m += m[row][column]
    return sum_m


rows, columns = map(int, input().split(', '))
matrix = get_matrix(rows, columns)
sum_matrix = get_sum_matrix(matrix)

print(sum_matrix)
print(matrix)
