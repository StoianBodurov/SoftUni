numbers = [int(el) for el in input().split(', ')]
task_index = int(input())

sorted_number = sorted((v, i ) for i, v in enumerate(numbers))
clock_cycles = 0

for value, index in sorted_number:
    clock_cycles += value
    if index == task_index:
        break
print(clock_cycles)