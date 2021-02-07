heroes = {el: {'items': [], 'cost': 0} for el in input().split(', ')}

while True:
    command = input()
    if command == 'End':
        break
    name, item, cost = command.split('-')
    if item not in heroes[name]['items']:
        heroes[name]['items'].append(item)
        heroes[name]['cost'] += int(cost)

for k, v in heroes.items():
    print(f'{k} -> Items: {len(v["items"])}, Cost: {v["cost"]}')
