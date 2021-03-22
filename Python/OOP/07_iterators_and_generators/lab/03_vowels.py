class vowels:
    vowels = {
        'A', 'E', 'I', 'U', 'Y', 'O'
        'a', 'e', 'i', 'u', 'y', 'o'
    }

    def __init__(self, text):
        self.text = text
        self.index = 0

    def __iter__(self):
        return self

    def __next__(self):
        if self.index >= len(self.text):
            raise StopIteration

        ch = self.text[self.index]
        self.index += 1

        if ch not in self.vowels:
            return self.__next__()

        return ch


my_string = vowels('Abcedifuty0o')
for char in my_string:
    print(char)
