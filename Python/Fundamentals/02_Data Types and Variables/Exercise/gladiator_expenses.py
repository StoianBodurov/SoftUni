lost_fights_count = int(input())
helmet_price = float(input())
sword_price = float(input())
shield_price = float(input())
armor_price = float(input())


count_helmet = 0
count_sword = 0
count_shild = 0
count_armor = 0


for lost in range(1, lost_fights_count + 1):
    if lost % 2 == 0:
        count_helmet += 1
    if lost % 3 == 0:
        count_sword += 1
    if lost % 2 == 0 and lost % 3 == 0:
        count_shild += 1
        if count_shild % 2 == 0:
            count_armor += 1

total_price = count_shild * shield_price + count_armor * armor_price + count_sword * sword_price + count_helmet * helmet_price

print(f'Gladiator expenses: {total_price:.2f} aureus')


