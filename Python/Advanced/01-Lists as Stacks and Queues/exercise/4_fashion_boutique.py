clothes = [int(el) for el in input().split(' ')]
rack_capacity = int(input())
current_capacity = rack_capacity
rack_count = 1

while len(clothes) > 0:
    current_clothing = clothes.pop()
    if current_clothing <= current_capacity:
        current_capacity -= current_clothing

    else:
        rack_count += 1
        current_capacity = rack_capacity
        current_capacity -= current_clothing


print(rack_count)
