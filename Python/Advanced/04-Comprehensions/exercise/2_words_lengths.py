# data = input().split(', ')
#
# words_lenghts = [f'{el} -> {len(el)}' for el in data]
#
# print(', '.join(words_lenghts))

print(', '.join([f'{el} -> {len(el)}' for el in input().split(', ')]))