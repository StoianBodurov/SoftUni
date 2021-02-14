def read_square(n):
    matrix = []
    for _ in range(n):
        matrix.append(input().split(' '))
    return matrix


def search_walls_indexes(matrix):
    walls = []
    for r in range(len(matrix)):
        for c in range(len(matrix[r])):
            if matrix[r][c] == 'X':
                walls.append((r, c))
    return walls


def is_valid_indexes(matrix, r, c):
    return 0 <= r < len(matrix) and 0 <= c < len(matrix)


def player_place(matrix):
    row = 0
    column = 0
    for r in range(len(matrix)):
        for c in range(len(matrix[r])):
            if matrix[r][c] == 'P':
                row = r
                column = c
    return row, column


commands = {'up': (-1, 0), 'down': (1, 0), 'left': (0, -1), 'right': (0, 1)}

size = int(input())
field = read_square(size)
walls = search_walls_indexes(field)
player_row_index, player_columns_index = player_place(field)
coins = 0
path = []

while coins < 100:
    command = input()
    row, column = commands[command]
    new_row = player_row_index + row
    new_column = player_columns_index + column
    if is_valid_indexes(field, new_row, new_column):
        if (new_row, new_column) not in walls:
            if field[new_row][new_column].isdigit():
                coins += int(field[new_row][new_column])
                path.append([new_row, new_column])
                player_row_index = new_row
                player_columns_index = new_column
        else:
            coins //= 2
            break
    else:
        coins //= 2
        break
if coins >= 100:
    print(f"You won! You've collected {coins} coins.")
else:
    print(f"Game over! You've collected {coins} coins.")
print('Your path:')
print(*path, sep='\n')
