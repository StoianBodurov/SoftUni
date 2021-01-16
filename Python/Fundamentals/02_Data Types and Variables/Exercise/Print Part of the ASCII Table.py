first_index = int(input())
last_index = int(input())


for i in range(first_index, last_index + 1):
    character = chr(i)
    print(character, end = ' ')