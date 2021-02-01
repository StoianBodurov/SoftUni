numbers = [int(el) for el in input().split()]


def sum_of_positive_negative_nums(nums):
    positive_nums = []
    negative_nums = []
    for num in nums:
        if num >= 0:
            positive_nums.append(num)
        else:
            negative_nums.append(num)

    return sum(positive_nums), sum(negative_nums)


def print_result(sum_positive, sum_negative):
    print(*(sum_negative, sum_positive), sep='\n')
    if sum_positive < abs(sum_negative):
        print('The negatives are stronger than the positives')
    else:
        print('The positives are stronger than the negatives')


p_sum, n_sum = sum_of_positive_negative_nums(numbers)
print_result(p_sum, n_sum)