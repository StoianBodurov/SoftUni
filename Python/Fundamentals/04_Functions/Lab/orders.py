input_product = input()
input_quantity = int(input())


def total_price(product, quantity):
    price = 0
    if product == 'coffee':
        price = quantity * 1.5
    elif product == 'water':
        price = quantity * 1
    elif product == 'coke':
        price = quantity * 1.4
    else:
        price = quantity * 2
    return f'{price:.2f}'


print(total_price(input_product, input_quantity))
