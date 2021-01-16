input_list = input().split(", ")


def reversed_num(num):
    rev_num = []
    for i in range(len(num) - 1, -1, -1):
        rev_num.append(num[i])
    return rev_num


def correct_num(num):
    correct = []
    for i in range(0, len(num)):
        correct.append(num[i])
    return correct


for num in input_list:
    if correct_num(num) == reversed_num(num):
        print('True')
    else:
        print('False')
