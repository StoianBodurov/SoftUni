row, col = [int(el) for el in input().split(' ')]

[print(*el) for el in [[chr(ord('a') + r) + chr(ord('a') + r + c) + chr(ord('a') + r) for c in range(col)] for r in range(row)]]