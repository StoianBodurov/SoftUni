def round_num(nums):
    return [round(num) for num in nums]


numbers = [float(el) for el in input().split(' ')]
print(round_num(numbers))