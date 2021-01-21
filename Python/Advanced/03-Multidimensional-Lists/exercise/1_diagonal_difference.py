def get_matrix(row_numbers):
    matrix = []
    for _ in range(row_numbers):
        row = list(map(int, input().split(' ')))
        matrix.append(row)

    return matrix


def get_primary_diagonal_sum(matrix):
    sum_diagonal = 0
    for i in range(len(matrix)):
        sum_diagonal += matrix[i][i]

    return sum_diagonal


def get_secondary_diagonal_sum(matrix):
    sum_diagonal = 0
    for r in range(len(matrix) - 1, -1, -1):
        sum_diagonal += matrix[r][len(matrix) - r - 1]
    return sum_diagonal


def print_result(num_1, num_2):
    print(abs(num_1 - num_2))


n = int(input())
main_matrix = get_matrix(n)
sum_primary_diagonal = get_primary_diagonal_sum(main_matrix)
sum_secondary_diagonal = get_secondary_diagonal_sum(main_matrix)
print_result(sum_secondary_diagonal, sum_primary_diagonal)


