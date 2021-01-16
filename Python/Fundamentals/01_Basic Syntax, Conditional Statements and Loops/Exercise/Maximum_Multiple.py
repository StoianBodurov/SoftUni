divisor = int(input())
bound = int(input())
N = 0

for n in range(divisor + 1, bound + 1):
    if n % divisor == 0:
        if N < n:
            N = n
print(N)

