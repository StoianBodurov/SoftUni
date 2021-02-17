def get_magic_triangle(n):
    matrix = []
    for r in range(n):
        row = []
        if r == 0:
            row.append(1)
        else:
            for c in range(len(matrix[r - 1]) + 1):
                col1 = 0
                col2 = 0

                if 0 <= c - 1 < len(matrix[r - 1]):
                    col1 = matrix[r - 1][c - 1]
                if 0 <= c < len(matrix[r - 1]):
                    col2 = matrix[r - 1][c]
                row.append(col1 + col2)
        matrix.append(row)
    return matrix


print(get_magic_triangle(7))
