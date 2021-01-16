number = int(input())


def loading_bar(num):
    symbol1 = num // 10
    symbol2 = (100 - num) // 10

    if num < 100:
        print(f'{num}% [{"%" * symbol1}{"." * symbol2}]\nStill loading...')
    elif num == 100:
        print(f'{num}% Complete!\n[{"%" * symbol1}{"." * symbol2}]')


loading_bar(number)
