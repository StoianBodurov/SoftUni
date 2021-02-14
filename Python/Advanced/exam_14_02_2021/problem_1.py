from collections import deque

firework_types = {'Palm Fireworks': 0, 'Willow Fireworks': 0, 'Crossette Fireworks': 0}


def palm_fireworks(x, y):
    sum_value = x + y
    return sum_value % 3 == 0 and sum_value % 5 != 0


def willow_fireworks(x, y):
    sum_value = x + y
    return sum_value % 5 == 0 and sum_value % 3 != 0


def crossette_fireworks(x, y):
    sum_value = x + y
    return sum_value % 3 == 0 and sum_value % 5 == 0


firework_effects = deque(int(el) for el in input().split(', '))
explosive_powers = [int(el) for el in input().split(', ')]

successfully_prepared = False


while True:
    firework_effects = deque([el for el in firework_effects if el >0])
    explosive_powers = [el for el in explosive_powers if el > 0]
    if not (firework_effects and explosive_powers):
        break
    firework_effect = firework_effects.popleft()
    explosive_power = explosive_powers.pop()
    # if firework_effect <= 0 or explosive_power <= 0:
    #     if firework_effect > 0:
    #         firework_effects.appendleft(firework_effect)
    #     if explosive_power > 0:
    #         explosive_powers.append(explosive_power)
    #     continue
    if palm_fireworks(firework_effect, explosive_power):
        firework_types['Palm Fireworks'] += 1
    elif willow_fireworks(firework_effect, explosive_power):
        firework_types['Willow Fireworks'] += 1
    elif crossette_fireworks(firework_effect, explosive_power):
        firework_types['Crossette Fireworks'] += 1
    else:
        firework_effects.append(firework_effect - 1)
        explosive_powers.append(explosive_power)

    firework_types_value = list(firework_types.values())
    if firework_types_value[0] >= 3 and firework_types_value[1] >= 3 and firework_types_value[2] >= 3:
        successfully_prepared = True
        break

if successfully_prepared:
    print('Congrats! You made the perfect firework show!')
else:
    print('Sorry. You can’t make the perfect firework show.')
if firework_effects:
    print(f"Firework Effects left: {', '.join(str(el) for el in firework_effects)}")
if explosive_powers:
    print(f"Explosive Power left: {', '.join(str(el) for el in explosive_powers)}")


sorted_firework_types = sorted(firework_types.items(), key=lambda x: -x[1])
for k, v in sorted_firework_types:
    print(f'{k}: {v}')

