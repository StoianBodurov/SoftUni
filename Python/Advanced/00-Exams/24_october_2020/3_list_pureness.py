import sys
from collections import  deque


def best_list_pureness(*args):
    a, count_of_rotation = args
    a = deque([int(el) for el in a])
    count_of_rotation = int(count_of_rotation)
    count = 0
    max_sum_iteration = 0
    max_sum = - sys.maxsize

    while True:
        current_sum = 0
        for i in range(len(a)):
            current_sum += (i * a[i])
            if current_sum > max_sum:
                max_sum = current_sum
                max_sum_iteration = count

        if count == count_of_rotation:
            break
        count += 1
        a.rotate()

    return f'Best pureness {max_sum} after {max_sum_iteration} rotations'