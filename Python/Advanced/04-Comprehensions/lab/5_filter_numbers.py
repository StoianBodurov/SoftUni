start_num = int(input())
end_num = int(input())


filtered_number = [num for num in range(start_num, end_num + 1) if any(num % el == 0 for el in range(2, 11))]
print(filtered_number)