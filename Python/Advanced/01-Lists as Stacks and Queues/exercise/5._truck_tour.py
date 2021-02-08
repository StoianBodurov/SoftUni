from collections import deque

n = int(input())
gas_stations = []
tank_capacity = 0
valid = True

for _ in range(n):
    gas_stations.append(input())

que = deque(gas_stations)

for index in range(n):
    for el in que:
        petrol, distance = el.split()
        petrol = int(petrol)
        distance = int(distance)
        tank_capacity += petrol
        if tank_capacity >= distance:
            tank_capacity -= distance
        else:
            tank_capacity = 0
            que.rotate(-1)
            valid = False
            break
    if valid:
        print(index)
        break
    else:
        valid = True
