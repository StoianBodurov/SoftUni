budget = float(input())
flour_price_kg = float(input())

eggs_pack_price = 0.75 * flour_price_kg
milk_liter_price = 1.25 * flour_price_kg
cozonac_price = flour_price_kg + eggs_pack_price + 0.25 * milk_liter_price

cozunac_counter = 0
colored_eggs_count = 0

while budget >= cozonac_price:

    cozunac_counter += 1
    colored_eggs_count += 3
    budget -= cozonac_price

    if cozunac_counter % 3 == 0:
        colored_eggs_count -= cozunac_counter - 2


print(f'You made {cozunac_counter} cozonacs! Now you have {colored_eggs_count} eggs and {budget:.2f}BGN left.')