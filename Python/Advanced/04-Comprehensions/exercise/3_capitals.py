countries = input().split(', ')
capitals = input().split(', ')

countries_capitals = {countries[index]: capitals[index] for index in range(len(countries))}
for k, v in countries_capitals.items():
    print(f'{k} -> {v}')
