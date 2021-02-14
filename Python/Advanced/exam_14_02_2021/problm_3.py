from collections import deque


def stock_availability(stock, *args):
    data = deque(stock)
    args = [str(el) for el in args]
    command = args[0]
    if command == 'delivery':
        for el in args[1::]:
            data.append(el)
    else:
        if len(args) == 1:
            data.popleft()
        else:

            if args[1].isdigit():
                for _ in range(int(args[1])):
                    data.popleft()
            else:
                for el in args[1::]:
                    while el in data:
                        data.remove(el)

    return list(data)
