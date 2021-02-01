def odd_sum(nums):
    return sum([el for el in nums if el % 2 != 0])


def even_sum(nums):
    return sum([el for el in nums if el % 2 == 0])


def result(com, num):
    if com == 'Odd':
        return odd_sum(num) * len(num)

    return even_sum(num) * len(num)


command = input()
numbers = [int(el) for el in input().split()]

print(result(command, numbers))

