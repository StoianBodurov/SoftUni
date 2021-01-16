integers = input().split()
n = int(input())

integers_list = []


for num in integers:
    integers_list.append(int(num))

# while n > 0:
#     integers_list.remove(min(integers_list))
#     n -= 1

for i in range(n):
    min_number = 100000000000000000000000
    for num in integers_list:
        if num < min_number:
            min_number = num

    integers_list.remove(min_number)
print(integers_list)
