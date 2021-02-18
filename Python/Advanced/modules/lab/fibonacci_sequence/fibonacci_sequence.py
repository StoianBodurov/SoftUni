seq = [0, 1]


def create_sequence(n):
    global seq
    if n == 1:
        seq = [0]
    elif n == 2:
        seq = [0, 1]
    elif n == 0:
        seq = []
    else:
        for _ in range(2, n):
            seq.append(seq[-1] + seq[-2])
    print(*seq)


def get_number_location(x):
    if x in seq:
        print(f'The number - {x} is at index {seq.index(x)}')
    else:
        print(f'The number {x} is not in the sequence')