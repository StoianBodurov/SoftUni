names_of_gifts = input().split()
command = input()

while command != 'No Money':
    command_list = command.split()

    if command_list[0] == 'OutOfStock':
        for i in range(len(names_of_gifts)):
            if names_of_gifts[i] == command_list[1]:
                names_of_gifts[i] = 'None'

    elif command_list[0] == 'Required':
        index = int(command_list[2])
        if 0 <= index < len(names_of_gifts):
            names_of_gifts[index] = command_list[1]
    else:
        index = len(names_of_gifts) - 1
        names_of_gifts[index] = command_list[1]

    command = input()

for gift in names_of_gifts:
    if gift != 'None':
        print(gift, end=' ')