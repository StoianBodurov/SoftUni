rows = int(input())

matrix = []

for _ in range(rows):
    row = list(input())
    matrix.append(row)

find_symbol = input()
indexes = tuple()
is_find = False
for r in range(len(matrix)):
    for c in range(len(matrix[r])):
        if matrix[r][c] == find_symbol:
            indexes = (r, c)
            print(indexes)
            is_find = True
            break

    if is_find:
        break
if not indexes:
    print(f"{find_symbol} does not occur in the matrix")