grade = float(input())


def grades(a) -> object:
    if 2 <= a <= 2.99:
        print('Fail')
    elif 3 <= a <= 3.49:
        print('Poor')
    elif 3.5 <= a <= 4.49:
        print('Good')
    elif 4.5 <= a <= 5.49:
        print('Very Good')
    elif 5.5 <= a <= 6:
        print('Excellent')


grades(grade)
