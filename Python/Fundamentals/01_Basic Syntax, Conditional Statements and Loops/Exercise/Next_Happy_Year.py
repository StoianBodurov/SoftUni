year = int(input())

while True:
    year += 1
    first_digit = year % 10
    second_digit = (year // 10) % 10
    third_digit = (year // 100) % 10
    fourth_digit = year // 1000
    if first_digit != second_digit and first_digit != third_digit and first_digit != fourth_digit and second_digit != third_digit and second_digit != fourth_digit and third_digit != fourth_digit:
        print(year)
        break
