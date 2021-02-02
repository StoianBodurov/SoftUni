phone_book = {}

while True:
    data = input()
    if data.isdigit():
        break

    name, phone_number = data.split('-')
    if name not in phone_book:
        phone_book[name] = phone_number

    phone_book[name] = phone_number

for _ in range(int(data)):
    person = input()
    if person not in phone_book:
        print(f'Contact {person} does not exist.')
    else:
        print(f'{person} -> {phone_book[person]}')
