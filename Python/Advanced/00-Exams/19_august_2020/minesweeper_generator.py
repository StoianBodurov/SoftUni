import re


def red_matrix(n):
    matrix = []
    for _ in range(n):
        row = [''] * n
        matrix.append(row)
    return matrix


def is_valid_position(matrix, r, c):
    if 0 <= r < len(matrix) and 0 <= c < len(matrix):
        return True
    return False


field_size = int(input())
bombs_number = int(input())
field = red_matrix(field_size)

for _ in range(bombs_number):
    data = input()
    matches = re.findall(r"[0-9]+", data)
    row = int(matches[0])
    col = int(matches[-1])
    field[row][col] = '*'


for row_index in range(len(field)):

    for col_index in range(len(field)):
        count = 0
        symbol = field[row_index][col_index]
        if symbol != '*':
            if is_valid_position(field, row_index, col_index + 1):
                if field[row_index][col_index + 1] == '*':
                    count += 1
            if is_valid_position(field, row_index, col_index - 1):
                if field[row_index][col_index - 1] == '*':
                    count += 1
            if is_valid_position(field, row_index + 1, col_index):
                if field[row_index + 1][col_index] == '*':
                    count += 1
            if is_valid_position(field, row_index - 1, col_index):
                if field[row_index - 1][col_index] == '*':
                    count += 1
            if is_valid_position(field, row_index + 1, col_index + 1):
                if field[row_index + 1][col_index + 1] == '*':
                    count += 1
            if is_valid_position(field, row_index - 1, col_index - 1):
                if field[row_index - 1][col_index - 1] == '*':
                    count += 1
            if is_valid_position(field, row_index - 1, col_index + 1):
                if field[row_index - 1][col_index + 1] == '*':
                    count += 1
            if is_valid_position(field, row_index + 1, col_index - 1):
                if field[row_index + 1][col_index - 1] == '*':
                    count += 1
            field[row_index][col_index] = count
for row in field:
    print(*row, sep=' ')
