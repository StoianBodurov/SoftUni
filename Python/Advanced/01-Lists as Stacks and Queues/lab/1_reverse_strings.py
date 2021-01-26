text = input()

stack = []

reversed_stack = []

for el in text:
    stack.append(el)

while stack:
    reversed_stack.append(stack.pop())

print(''.join(reversed_stack))
