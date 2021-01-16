input_simbol1 = input()
input_simbol2 = input()


def char_range(start_character, end_charter):
    for i in range(ord(start_character) + 1, ord(end_charter)):
        print(chr(i), end=' ')
    print()


char_range(input_simbol1, input_simbol2)
