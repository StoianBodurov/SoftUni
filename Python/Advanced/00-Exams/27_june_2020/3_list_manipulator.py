from collections import deque


def list_manipulator(data, command, *args):
    data = deque(data)
    places = args[0]
    nums = None

    if command == 'remove':
        if len(args) > 1:
            nums = int(args[-1])
        if places == 'end':
            if nums:
                for i in range(nums):
                    data.pop()
            else:
                data.pop()
        else:
            if nums:
                for i in range(nums):
                    data.popleft()
            else:
                data.popleft()

    elif command == 'add':
        nums = args[1::]
        if places == 'end':
            for i in nums:
                data.append(i)
        else:
            for i in range(len(nums) - 1, -1, -1):
                data.appendleft(nums[i])

    return list(data)


print(list_manipulator([1,2,3], "remove", "end"))
print(list_manipulator([1,2,3], "remove", "beginning"))
print(list_manipulator([1,2,3], "add", "beginning", 20))
print(list_manipulator([1,2,3], "add", "end", 30))
print(list_manipulator([1,2,3], "remove", "end", 2))
print(list_manipulator([1,2,3], "remove", "beginning", 2))
print(list_manipulator([1,2,3], "add", "beginning", 20, 30, 40))
print(list_manipulator([1,2,3], "add", "end", 30, 40, 50))

