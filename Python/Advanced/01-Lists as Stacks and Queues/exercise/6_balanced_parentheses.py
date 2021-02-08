line = input()
open_parentheses = '({['

validator = True
stack = []
parentheses = {')': '(',
               ']': '[',
               '}': '{', }

for el in line:
    if el in open_parentheses:
        stack.append(el)
    else:
        if not stack:
            validator = False
            break
        if not parentheses[el] == stack.pop():
            validator = False
            break

if validator and not stack:
    print('YES')
else:
    print('NO')
