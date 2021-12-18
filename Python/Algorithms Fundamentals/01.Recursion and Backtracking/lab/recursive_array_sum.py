arr = [int(i) for i in input().split(' ')]


def array_sum(aray, index=0):
    if index == len(aray):
        return 0

    return aray[index] + array_sum(aray, index + 1)


print(array_sum(arr))