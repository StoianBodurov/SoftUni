n = int(input())
capacity = 255
while n > 0:
    n -= 1
    liter_receive = int(input())
    if liter_receive > capacity:
        print('Insufficient capacity!')
    else:
        capacity -= liter_receive

print(255 - capacity)