fires_their_cells = input().split('#')
water = int(input())

total_fire = 0
effort = 0

print('Cells:')

for index in fires_their_cells:
    cells = index.split(' = ')
    cells_water = int(cells[1])
    if cells[0] == 'High' and 80 < cells_water <= 125:
        if cells_water <= water:
            water -= cells_water
            total_fire += cells_water
            effort += cells_water * 0.25
            print(f' - {cells_water}')
    elif cells[0] == 'Medium' and 50 < cells_water <= 80:
        if cells_water <= water:
            water -= cells_water
            total_fire += cells_water
            effort += cells_water * 0.25
            print(f' - {cells_water}')
    elif cells[0] == 'Low' and 0 < cells_water <= 50:
        if cells_water <= water:
            water -= cells_water
            total_fire += cells_water
            effort += cells_water * 0.25
            print(f' - {cells_water}')

print(f'Effort: {effort:.2f}')
print(f'Total Fire: {total_fire}')