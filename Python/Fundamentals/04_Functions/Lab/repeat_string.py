input_string = input()
input_count = int(input())


def repeat_string(string, count):
    new_string = string * count
    return  new_string


print(repeat_string(input_string, input_count))