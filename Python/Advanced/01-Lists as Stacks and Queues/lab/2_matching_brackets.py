line = input()


stack = []

# for el in line:
#     if el == '(':
#         stack.append('')
#
#     for i in range(len(stack)):
#         stack[i] += el
#
#     if el == ')':
#         print(stack.pop())
#
#
for i in range(len(line)):
    if line[i] == '(':
        stack.append(i)

    if line[i] == ')':
        start_index = stack.pop()
        print(line[start_index: i + 1])