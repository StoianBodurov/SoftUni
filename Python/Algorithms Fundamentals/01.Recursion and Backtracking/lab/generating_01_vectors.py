n = int(input())

array = [0 for i in range(n)]


def get01_vectors(index, array):
    if index >= len(array):
        print(' '.join([str(el) for el in array]))
    else:
        for i in range(0, 2):
            array[index] = i
            get01_vectors(index + 1, array)


get01_vectors(0, array)
