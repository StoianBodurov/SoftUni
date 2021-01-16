
def exchange(new_list, new_command):
    exchange_list = []
    exchange_num = int(new_command[1]) + 1
    if exchange_num > len(new_list):
        return 'Invalid index'
    else:
        for i in range(exchange_num, len(new_list)):
            exchange_list.append(int(new_list[i]))
        for j in range(0, exchange_num):
            exchange_list.append(int(new_list[j]))
        return exchange_list


def max_min(new_list, new_command):
    max_number = - (2 ** 31)
    min_number = 2 ** 31 - 1
    index = None
    if new_command[0] == 'max':
        if new_command[1] == 'even':
            for n in range(0, len(new_list)):
                if int(new_list[n]) % 2 == 0:
                    digit = int(new_list[n])
                    if digit >= max_number:
                        max_number = digit
                        index = n
        else:
            for n in range(0, len(new_list)):
                if int(new_list[n]) % 2 != 0:
                    digit = int(new_list[n])
                    if digit >= max_number:
                        max_number = digit
                        index = n
    else:
        if new_command[1] == 'even':
            for n in range(0, len(new_list) ):
                if int(new_list[n]) % 2 == 0:
                    digit = int(new_list[n])
                    if digit <= min_number:
                        min_number = digit
                        index = n
        else:
            for n in range(0, len(new_list)):
                if int(new_list[n]) % 2 != 0:
                    digit = int(new_list[n])
                    if digit <= min_number:
                        min_number = digit
                        index = n
    if index is None:
        return 'No matches'
    else:
        return index




def first_last(new_list, new_command):
    counter = int(new_command[1])
    even_odd_list = []
    if len(new_list) < counter:
        return 'Invalid count'
    else:
        if new_command[0] == 'first':
            if new_command[2] == 'even':
                for i in range(0, len(new_list)):
                    if int(new_list[i]) % 2 == 0:
                        even_odd_list.append(int(new_list[i]))
                        counter -= 1
                    if counter == 0:
                        break
            elif new_command[2] == 'odd':
                for i in range(0, len(new_list)):
                    if int(new_list[i]) % 2 != 0:
                        even_odd_list.append(int(new_list[i]))
                        counter -= 1
                    if counter == 0:
                        break
            return even_odd_list
        else:
            if new_command[2] == 'even':
                for i in range((len(new_list) - 1), -1, -1):
                    if int(new_list[i]) % 2 == 0:
                        even_odd_list.append(int(new_list[i]))
                        counter -= 1
                    if counter == 0:
                        break
            elif new_command[2] == 'odd':
                for i in range((len(new_list) - 1), -1, -1):
                    if int(new_list[i]) % 2 != 0:
                        even_odd_list.append(int(new_list[i]))
                        counter -= 1
                    if counter == 0:
                        break
            return even_odd_list


input_list = input().split()
input_command = input().split()
last_list = input_list


while input_command[0] != 'end':
    if input_command[0] == 'exchange':
        if exchange(last_list, input_command) == 'Invalid index':
            print(exchange(last_list, input_command))
        else:
            last_list = exchange(last_list, input_command)
    elif input_command[0] == 'max' or input_command[0] == 'min':
        print(max_min(last_list, input_command))
    elif input_command[0] == 'first' or input_command[0] == 'last':
        print(first_last(last_list, input_command))
    input_command = input().split()

print(last_list)
