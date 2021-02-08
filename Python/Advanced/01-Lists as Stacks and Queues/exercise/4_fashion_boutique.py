clothes = [int(el) for el in input().split(' ')]
rack_capacity = int(input())
clothing_sum = 0
rack_count = 0

while len(clothes) > 0:
    current_clothing = clothes.pop()
    clothing_sum += current_clothing
    if clothing_sum > rack_capacity:
        clothing_sum = 0
        rack_count += 1
        clothes.append(current_clothing)
    if clothing_sum == rack_capacity:
        rack_count += 1
        clothing_sum = 0
    if not clothes:
        rack_count += 1

print(rack_count)



