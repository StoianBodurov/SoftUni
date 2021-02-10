def red_matrix(n):
    matrix = []
    for _ in range(n):
        row = list(input())
        matrix.append(row)
    return matrix


def get_player_position(matrix):
    row_index = 0
    col_index = 0
    for r in range(len(matrix)):
        for c in range(len(matrix)):
            if matrix[r][c] == 'P':
                row_index = r
                col_index = c
    return row_index, col_index


initial_string = list(input())
square_size = int(input())
field = red_matrix(square_size)
n_comm = int(input())

for _ in range(n_comm):
    command = input()
    row, columns = get_player_position(field)
    if command == 'up':
        if row == 0:
            initial_string.pop()
        else:
            symbol = field[row-1][columns]
            if symbol.isalpha():
                initial_string.append(symbol)
                field[row][columns] = '-'
                field[row - 1][columns] = 'P'
            else:
                field[row][columns] = '-'
                field[row - 1][columns] = 'P'
    elif command == 'down':
        if row == (len(field) - 1):
            initial_string.pop()
        else:
            symbol = field[row + 1][columns]
            if symbol.isalpha():
                initial_string.append(symbol)
                field[row][columns] = '-'
                field[row + 1][columns] = 'P'
            else:
                field[row][columns] = '-'
                field[row + 1][columns] = 'P'
    elif command == 'left':
        if columns == 0:
            initial_string.pop()
        else:
            symbol = field[row][columns - 1]
            if symbol.isalpha():
                initial_string.append(symbol)
                field[row][columns] = '-'
                field[row][columns - 1] = 'P'
            else:
                field[row][columns] = '-'
                field[row][columns - 1] = 'P'
    elif command == 'right':
        if columns == (len(field) - 1):
            initial_string.pop()
        else:
            symbol = field[row][columns + 1]
            if symbol.isalpha():
                initial_string.append(symbol)
                field[row][columns] = '-'
                field[row][columns + 1] = 'P'
            else:
                field[row][columns] = '-'
                field[row][columns + 1] = 'P'


print(''.join(initial_string))

for row in field:
    print(*row, sep='')
