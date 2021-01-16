events = input().split('|')

energy = 100
coins = 100
bankrupt = True



for item in events:

    day_event = item.split('-')
    event = day_event[0]
    event_count = int(day_event[1])
    old_energy = energy

    if event == 'rest':
        energy += event_count
        if energy > 100:
            energy = 100

        print(f'You gained {energy - old_energy} energy.')
        print(f'Current energy: {energy}.')

    elif event == 'order':
        if energy >= 30:
            energy -= 30
            old_coins = coins
            coins += event_count
            print(f'You earned {coins - old_coins} coins.')
        else:
            energy += 50
            if energy > 100:
                energy = 100
            print('You had to rest!')
    else:
        coins -= event_count
        if coins > 0:
            print(f'You bought {event}.')
        else:
            bankrupt = False
            print(f'Closed! Cannot afford {event}.')
            break
if bankrupt:
    print(f'Day completed!\nCoins: {coins}\nEnergy: {energy}')


