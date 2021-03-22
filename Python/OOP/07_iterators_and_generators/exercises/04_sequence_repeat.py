class sequence_repeat:
    def __init__(self, sequence, number):
        self.sequence = sequence
        self.number = number
        self.index = 0

    def __iter__(self):
        return self

    def __next__(self):
        if self.number < 1:
            raise StopIteration

        if self.index >= len(self.sequence):
            self.index = 0

        index = self.index
        self.index += 1
        self.number -= 1
        ch = self.sequence[index]
        return ch


result = sequence_repeat('abc', 5)
for item in result:
    print(item, end ='')
