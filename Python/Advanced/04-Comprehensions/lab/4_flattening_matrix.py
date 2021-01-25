def read_matrix():
    rows = int(input())
    return [map(int, input(). split(', ')) for _ in range(rows)]


matrix = read_matrix()
flattened = [num for row in matrix for num in row]
print(flattened)