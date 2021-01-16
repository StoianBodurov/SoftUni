cards = input().split()
number_faro_shuffles = int(input())
half_lenght = len(cards) // 2

for i in range(number_faro_shuffles):
    result = []
    for index in range(half_lenght):
        result.append(cards[index])
        result.append(cards[index + half_lenght])

    cards = result

print(cards)
