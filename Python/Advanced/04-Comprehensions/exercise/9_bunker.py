bunker = {el: {} for el in input().split(', ')}
n = int(input())

for _ in range(n):
    categories, items, info = input().split(' - ')
    quantity, quality = [int(z) for x in info.split(";") for z in x.split(":") if z.isdigit()]

    bunker[categories].update({items: [quantity, quality]})

count_items = sum([int(v[0]) for key, value in bunker.items() for k, v in value.items()])
sum_quality = sum([int(v[1]) for key, value in bunker.items() for k, v in value.items()])
avg_quality = sum_quality / len(bunker)
print(f'Count of items: {count_items}')
print(f'Average quality: {avg_quality:.2f}')

for k, value in bunker.items():
    print(f"{k} -> {', '.join([el for el in value.keys()])}")