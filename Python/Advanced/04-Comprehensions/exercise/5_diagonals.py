def read_matrix():
    rows = int(input())
    matrix = []
    for _ in range(rows):
        row = [int(el) for el in input().split(', ')]
        matrix.append(row)

    return matrix


main_matrix = read_matrix()
first_diagonal = [main_matrix[row_index][row_index] for row_index in range(len(main_matrix))]
second_diagonal = [main_matrix[row_index][len(main_matrix) - row_index - 1] for row_index in range(len(main_matrix) - 1, -1, -1)]

print(f"First diagonal: {', '.join([str(el) for el in first_diagonal])}. Sum: {sum(first_diagonal)}")
print(f"Second diagonal: {', '.join([str(el) for el in second_diagonal][::-1])}. Sum: {sum(second_diagonal)}")
