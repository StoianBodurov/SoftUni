def vowel_filter(func):
    vowels = 'AEIOUYaeiouy'

    def wrapper():
        result = func()
        return [el for el in result if el in vowels]

    return wrapper


@vowel_filter
def get_letters():
    return ["a", "b", "c", "d", "e"]

print(get_letters())

