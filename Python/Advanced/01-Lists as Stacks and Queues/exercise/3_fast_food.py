from collections import deque

food_quantity = int(input())
orders = deque([int(el) for el in input().split(' ')])

print(max(orders))

while orders:
    order = orders.popleft()
    if food_quantity >= food_quantity:
        food_quantity -= order
    else:
        orders.appendleft(order)
        print(f"Orders left: {' '.join([str(el) for el in orders])}")
        break


if not orders:
    print('Orders complete')
