n = int(input())

vip_guest = set()
regular_guest = set()

for _ in range(n):
    guest = input()
    if len(guest) == 8:
        if guest[0].isdigit():
            vip_guest.add(guest)
        else:
            regular_guest.add(guest)

while True:
    command = input()
    if command == 'END':
        break
    if command in regular_guest:
        regular_guest.remove(command)
    if command in vip_guest:
        vip_guest.remove(command)

print(len(vip_guest) + len(regular_guest))
print('\n'.join(sorted(vip_guest)))
print('\n'.join(sorted(regular_guest)))