persons = int(input())
capasity = int(input())


man_per_coorses = persons // capasity

if persons % capasity != 0:
    man_per_coorses += 1

print(man_per_coorses)