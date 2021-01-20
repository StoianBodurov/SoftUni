rows = int(input())

matrix = []

for _ in range(rows):
    line = list(map(int, input().split(' ')))
    matrix.append(line)


sum_primary_diagonal = 0

for index in range(len(matrix)):
    sum_primary_diagonal += matrix[index][index]

print(sum_primary_diagonal)