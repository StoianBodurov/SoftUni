def read_matrix(n):
    matrix = []
    for _ in range(n):
        m_row = list(input())
        matrix.append(m_row)
    return matrix


def find_snake_coordinates(matrix):
    row_index = 0
    col_index = 0
    for r in range(len(matrix)):
        for c in range(len(matrix)):
            if matrix[r][c] == 'S':
                row_index = r
                col_index = c

    return row_index, col_index


def find_burrow_coordinates(matrix):
    coordinates = []
    for r in range(len(matrix)):
        for c in range(len(matrix)):
            if matrix[r][c] == 'B':
                coordinates.append((r, c))
    return coordinates


def is_territory(matrix, r_index, c_index):
    if 0 <= r_index < len(matrix) and 0 <= c_index < len(matrix):
        return True
    return False


num = int(input())
snake_territory = read_matrix(num)
borrow_coordinates = find_burrow_coordinates(snake_territory)
food = 0

while True:
    command = input()
    snake_row, snake_col = find_snake_coordinates(snake_territory)

    if command == 'left':
        if is_territory(snake_territory, snake_row, snake_col - 1):
            if snake_territory[snake_row][snake_col - 1] == 'B':
                borrow_coordinates.remove((snake_row, snake_col - 1))
                new_row, new_col = borrow_coordinates[0]
                snake_territory[new_row][new_col] = 'S'
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col - 1] = '.'

            elif snake_territory[snake_row][snake_col - 1] == '*':
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col - 1] = 'S'
                food += 1

            else:
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col - 1] = 'S'

        else:
            snake_territory[snake_row][snake_col] = '.'
            break
    elif command == 'right':
        if is_territory(snake_territory, snake_row, snake_col + 1):
            if snake_territory[snake_row][snake_col + 1] == 'B':
                borrow_coordinates.remove((snake_row, snake_col + 1))
                new_row, new_col = borrow_coordinates[0]
                snake_territory[new_row][new_col] = 'S'
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col + 1] = '.'

            if snake_territory[snake_row][snake_col + 1] == '*':
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col + 1] = 'S'
                food += 1
            else:
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row][snake_col + 1] = 'S'

        else:
            snake_territory[snake_row][snake_col] = '.'
            break

    elif command == 'up':
        if is_territory(snake_territory, snake_row - 1, snake_col):
            if snake_territory[snake_row - 1][snake_col] == 'B':
                borrow_coordinates.remove((snake_row - 1, snake_col))
                new_row, new_col = borrow_coordinates[0]
                snake_territory[new_row][new_col] = 'S'
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row - 1][snake_col] = '.'

            elif snake_territory[snake_row - 1][snake_col] == '*':
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row - 1][snake_col] = 'S'
                food += 1

            else:
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row - 1][snake_col] = 'S'
        else:
            snake_territory[snake_row][snake_col] = '.'
            break
    elif command == 'down':
        if is_territory(snake_territory, snake_row + 1, snake_col):
            if snake_territory[snake_row + 1][snake_col] == 'B':
                borrow_coordinates.remove((snake_row + 1, snake_col))
                new_row, new_col = borrow_coordinates[0]
                snake_territory[new_row][new_col] = 'S'
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row + 1][snake_col] = '.'
            elif snake_territory[snake_row + 1][snake_col] == '*':
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row + 1][snake_col] = 'S'
                food += 1
            else:
                snake_territory[snake_row][snake_col] = '.'
                snake_territory[snake_row + 1][snake_col] = 'S'
        else:
            snake_territory[snake_row][snake_col] = '.'
            break
    if food >= 10:
        break

if food >= 10:
    print('You won! You fed the snake.')

else:
    print('Game over!')

print(f'Food eaten: {food}')

for row in snake_territory:
    print(*row, sep='')
