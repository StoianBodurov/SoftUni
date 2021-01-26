n = int(input())
stack = []

for _ in range(n):
    command = input()
    if command.startswith('1'):
        element = int(command.split(' ')[1])
        stack.append(element)
    elif command.startswith('2'):
        if stack:
            stack.pop()
    elif command.startswith('3'):
        if stack:
            print(max(stack))
    elif command.startswith('4'):
        if stack:
            print(min(stack))

print(', '.join(str(el) for el in reversed(stack)))
