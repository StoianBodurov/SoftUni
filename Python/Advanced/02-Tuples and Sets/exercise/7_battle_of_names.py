n = int(input())

odd_result = set()
even_result = set()


for i in range(1, n+1):
    name = input()
    sums = 0
    for char in name:
        sums += ord(char)
    result = sums // i

    if result % 2 == 0:
        even_result.add(result)
    else:
        odd_result.add(result)

if odd_result == even_result:
    print(*(odd_result.union(even_result)), sep=', ')
elif sum(odd_result) > sum(even_result):
    print(*(odd_result.difference(even_result)), sep=', ')
elif sum(odd_result) < sum(even_result):
    print(*(even_result.symmetric_difference(odd_result)), sep=', ')




# print(odd_result)
# print(even_result)
# print(even_result.union(odd_result))
#
