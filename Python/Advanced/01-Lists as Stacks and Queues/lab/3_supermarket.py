from collections import deque

people = deque()

while True:
    command = input()
    if command == 'End':
        break

    if command == 'Paid':
        while people:
            print(people.popleft())
    else:
        person = command
        people.append(person)

print(f'{len(people)} people remaining.')