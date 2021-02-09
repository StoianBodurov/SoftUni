import sys


def read_matrix(size):
    matrix = []
    for _ in range(size):
        row = list(input())
        matrix.append(row)
    return matrix


def check_range_count(matrix, row_ind, col_ind):
    count = 0
    if (0 <= row_ind - 2 <= len(matrix) - 1) and (0 <= col_ind - 1 <= len(matrix) - 1):
        if matrix[row_ind - 2][col_ind - 1] == "K":
            count += 1
    if (0 <= row_ind - 2 <= len(matrix) - 1) and (0 <= col_ind + 1 <= len(matrix) - 1):
        if matrix[row_ind - 2][col_ind + 1] == "K":
            count += 1
    if (0 <= row_ind - 1 <= len(matrix) - 1) and (0 <= col_ind - 2 <= len(matrix) - 1):
        if matrix[row_ind - 1][col_ind - 2] == "K":
            count += 1
    if (0 <= row_ind - 1 <= len(matrix) - 1) and (0 <= col_ind + 2 <= len(matrix) - 1):
        if matrix[row_ind - 1][col_ind + 2] == "K":
            count += 1
    if (0 <= row_ind + 1 <= len(matrix) - 1) and (0 <= col_ind - 2 <= len(matrix) - 1):
        if matrix[row_ind + 1][col_ind - 2] == "K":
            count += 1
    if (0 <= row_ind + 1 <= len(matrix) - 1) and (0 <= col_ind + 2 <= len(matrix) - 1):
        if matrix[row_ind + 1][col_ind + 2] == "K":
            count += 1
    if (0 <= row_ind + 2 <= len(matrix) - 1) and (0 <= col_ind - 1 <= len(matrix) - 1):
        if matrix[row_ind + 2][col_ind - 1] == "K":
            count += 1
    if (0 <= row_ind + 2 <= len(matrix) - 1) and (0 <= col_ind + 1 <= len(matrix) - 1):
        if matrix[row_ind + 2][col_ind + 1] == "K":
            count += 1
    return count


size_of_bord = int(input())
board = read_matrix(size_of_bord)

max_count = -sys.maxsize - 1
target = []
removed = 0
counter = 0
while True:
    for r in range(size_of_bord):
        for c in range(size_of_bord):
            counter = 0

            if board[r][c] == "K":
                counter = check_range_count(board, r, c)
            if counter:
                if max_count < counter:
                    max_count = counter
                    target = [r, c]

    if target:
        board[target[0]][target[1]] = "0"
        removed += 1
    if not max_count:
        break
    max_count = 0
    target = []


print(removed)