text = input()
symbol_count = {}

for el in text:
    if el not in symbol_count:
        symbol_count[el] = 0
    symbol_count[el] += 1

sorted_symbol = sorted(symbol_count.items(), key=lambda x: x[0])

for k, v in sorted_symbol:
    print(f'{k}: {v} time/s')