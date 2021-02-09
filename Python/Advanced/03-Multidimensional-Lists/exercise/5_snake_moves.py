from collections import deque

rows, columns = map(int, input().split(' '))
snake = deque(input())
matrix = []

for _ in range(rows):
    row = [''] * columns
    matrix.append(row)


for row_index in range(rows):
    if row_index % 2 == 0:
        for col_index in range(columns):
            element = snake.popleft()
            matrix[row_index][col_index] = element
            snake.append(element)

    else:
        for col_index in range(columns -1, -1, -1):
            element = snake.popleft()
            matrix[row_index][col_index] = element
            snake.append(element)

for row in range(len(matrix)):
    print(*matrix[row], sep='')