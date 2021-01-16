text = input()
text_list = text.split()
numbers = []

for txt in text_list:
    num = - int(txt)
    numbers.append(num)
print(numbers)