def solution():

    def integers():
        num = 0
        while True:
            num += 1
            yield num

    def halves():
        for i in integers():
            yield i / 2

    def take(n, seq):
        nums = []
        for i in seq:
            if n < 1:
                break
            n -= 1
            nums.append(i)
        return nums

    return (take, halves, integers)



take = solution()[0]
halves = solution()[1]
print(take(5, halves()))

