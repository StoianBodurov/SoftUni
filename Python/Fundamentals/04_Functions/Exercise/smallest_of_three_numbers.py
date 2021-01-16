num1 = int(input())
num2 = int(input())
num3 = int(input())


def smallest_number(a, b, c):
    if a < b and a < c:
        return  a
    elif b < a and b < c:
        return b
    else:
        return c


print(smallest_number(num1, num2, num3))