def int_to_str(numbers):
    return [str(el) for el in numbers]


numbers = list(map(int, input().split(', ')))

positive_num = [num for num in numbers if num >= 0]
negative_num = [num for num in numbers if num < 0]
even_num = [num for num in numbers if num % 2 == 0]
odd_num = [num for num in numbers if num % 2 != 0]

print(f"Positive: {', '.join(int_to_str(positive_num))}")
print(f"Negative: {', '.join(int_to_str(negative_num))}")
print(f"Even: {', '.join(int_to_str(even_num))}")
print(f"Odd: {', '.join(int_to_str(odd_num))}")


