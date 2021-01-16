items_with_prices = input().split('|')
budget = int(input())

new_budget = 0
profit = 0

for item in items_with_prices:
    items = item.split('->')
    type = items[0]
    price = float(items[1])
    new_price = 0
    if type == 'Clothes' and price <= 50:
        if price <= budget:
            budget -= price
            new_price = price * 1.4
            new_budget += new_price
            profit += new_price - price
            print(f'{new_price:.2f}', end=' ')
    elif type == 'Shoes' and price <= 35:
        if price <= budget:
            budget -= price
            new_price = price * 1.4
            new_budget += new_price
            profit += new_price - price
            print(f'{new_price:.2f}', end=' ')
    elif type == 'Accessories' and price <= 20.50:
        if price <= budget:
            budget -= price
            new_price = price * 1.4
            new_budget += new_price
            profit += new_price - price
            print(f'{new_price:.2f}', end=' ')
print()
print(f'Profit: {profit:.2f}')

if new_budget + budget >= 150:
    print('Hello, France!')
else:
    print('Time to go.')
