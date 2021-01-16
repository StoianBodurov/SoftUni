input_number = input()


def odd_even_sum(number) -> object:
    even_sum = 0
    odd_sum = 0
    for i in range(0, len(number)):
        if int(number[i]) % 2 == 0:
            even_sum += int(number[i])
        else:
            odd_sum += int(number[i])

    print(f'Odd sum = {odd_sum}, Even sum = {even_sum}')


odd_even_sum(input_number)
