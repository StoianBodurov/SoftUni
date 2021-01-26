from collections import deque

water_quantity = int(input())

person_on_queue = deque()

while True:
    person = input()
    if person == 'Start':
        break

    person_on_queue.append(person)

while True:
    command = input()
    if command == 'End':
        break

    if command.startswith('refill'):
        add_liters = int(command.split(' ')[1])
        water_quantity += add_liters

    else:
        current_liters = int(command)
        if current_liters <= water_quantity:
            water_quantity -= current_liters
            print(f'{person_on_queue.popleft()} got water')
        else:
            print(f'{person_on_queue.popleft()} must wait')

print(f'{water_quantity} liters left')