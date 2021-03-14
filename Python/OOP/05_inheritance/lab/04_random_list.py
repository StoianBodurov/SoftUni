import random


class RandomList(list):
    def get_random_element(self):
        index_element = random.randint(0, len(self) - 1)
        element = self[index_element]
        self.pop(index_element)

        return element


rl = RandomList([1, 2, 1, 3, 4, 5])
while rl:
    print(rl.get_random_element())