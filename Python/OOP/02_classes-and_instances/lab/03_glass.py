class Glass:
    capacity = 250

    def __init__(self):
        self.content = 0
        self.left_capacity = Glass.capacity

    def fill(self, ml):
        if self.left_capacity >= ml:
            self.content += ml
            self.left_capacity -= ml
            return f'Glass filled with {ml} ml'

        return f'Cannot add {ml} ml'

    def empty(self):
        self.content = 0
        self.left_capacity = Glass.capacity
        return f'Glass is now empty'

    def info(self):
        space_left = Glass.capacity - self.content

        return f'{space_left} ml left'
