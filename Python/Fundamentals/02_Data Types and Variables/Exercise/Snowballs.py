number_snowballs = int(input())

snowball_snow_max = 0
snowball_time_max = 0
snowball_quality_max = 0
snowball_value_max = 0


while number_snowballs > 0:
    number_snowballs -= 1
    snowball_snow = int(input())
    snowball_time = int(input())
    snowball_quality = int(input())
    snowball_value = (snowball_snow / snowball_time) ** snowball_quality

    if snowball_value > snowball_value_max:
        snowball_value_max = snowball_value
        snowball_snow_max = snowball_snow
        snowball_time_max =  snowball_time
        snowball_quality_max = snowball_quality

print(f'{snowball_snow_max} : {snowball_time_max} = {snowball_value_max:.0f} ({snowball_quality_max})')