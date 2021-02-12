from collections import deque

bomb_effects = deque(int(el) for el in input().split(','))
bomb_casings = [int(el) for el in input().split(',')]
is_bang = False

bomb_types_count = {
    'Datura Bombs': 0,
    'Cherry Bombs': 0,
    'Smoke Decoy Bombs': 0,
}

mapper = {40:'Datura Bombs', 60: 'Cherry Bombs', 120: 'Smoke Decoy Bombs'}


while bomb_casings and bomb_effects:
    current_effect = bomb_effects.popleft()
    current_casing = bomb_casings.pop()
    bomb_value = current_casing + current_effect
    if bomb_value in mapper:
        bomb_types_count[mapper[bomb_value]] += 1
    else:
        bomb_casings.append(current_casing - 5)
        bomb_effects.appendleft(current_effect)

    bomb_values = list(bomb_types_count.values())
    if bomb_values[0] >= 3 and bomb_values[1] >= 3 and bomb_values[2] >= 3:
        is_bang =True
        break

if is_bang:
   print('Bene! You have successfully filled the bomb pouch!')
else:
    print('You don\'t have enough materials to fill the bomb pouch.')


if bomb_effects:
    print(f"Bomb Effects: {', '.join(str(el) for el in bomb_effects)}")
else:
    print('Bomb Effects: empty')

if bomb_casings:
    print(f"Bomb Casings: {', '.join(str(el) for el in bomb_casings)}")
else:
    print('Bomb Casings: empty')


sorted_bombs = sorted(bomb_types_count.items(), key=lambda x: x[0])

for k, v in sorted_bombs:
    print(f'{k}: {v}')
