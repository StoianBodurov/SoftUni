string_1 = input()
string_2 = input()


for i in range(0, len(string_1)):
    if string_1[i] != string_2[i]:
        for string_2_index in range(0, i +1):
            print(string_2[string_2_index], end = '')

        for string_1_index in range(i + 1, len(string_1)):
            print(string_1[string_1_index], end = '')
        print()
