class dictionary_iter:
    def __init__(self, dict_obj):
        self.dict_obj = dict_obj
        self.index = 0

    def __iter__(self):
        return self

    def __next__(self):
        if self.index >= len(self.dict_obj):
            raise StopIteration

        index = self.index
        self.index += 1
        dict_to_tuple = [(k, v) for k, v in self.dict_obj.items()]
        return dict_to_tuple[index]


result = dictionary_iter({1: "1", 2: "2"})
for x in result:
    print(x)
