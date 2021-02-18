from modules.lab.fibonacci_sequence.fibonacci_sequence import create_sequence, get_number_location


while True:
    commands = input().split(' ')
    if commands[0] == 'Stop':
        break
    command = commands[0]
    number = int(commands[-1])
    if command == 'Create':
        create_sequence(number)
    else:
        get_number_location(number)
