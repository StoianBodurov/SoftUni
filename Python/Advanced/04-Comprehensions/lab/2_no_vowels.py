text = input()

vowels = {'a', 'o', 'u', 'e', 'i'}
vowels = vowels.union(el.upper() for el in vowels)
result = [el for el in text if el not in vowels]

print(''.join(result))

