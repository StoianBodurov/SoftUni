class Store:
    def __init__(self, name, type, capacity):
        self.name = name
        self.type = type
        self.capacity = capacity
        self.items_count = 0
        self.items = {}

    def __repr__(self):
        return f'{self.name} of type {self.type} with capacity {self.capacity}'

    @classmethod
    def from_size(cls, name, type, size):
        return cls(name, type, size // 2)

    def add_item(self, item_name):
        if self.items_count == self.capacity:
            return 'Not enough capacity in the store'
        if item_name not in self.items:
            self.items[item_name] = 0
        self.items[item_name] += 1
        self.items_count += 1
        return f'{item_name} added to the store'

    def remove_item(self, item_name, amount):
        if not(item_name in self.items and amount <= self.items[item_name]):
            return f'Cannot remove {amount} {item_name}'
        return f'{amount} {item_name} removed from the store'


first_store = Store("First store", "Fruit and Veg", 20)
second_store = Store.from_size("Second store", "Clothes", 500)

print(first_store)
print(second_store)

print(first_store.add_item("potato"))
print(second_store.add_item("jeans"))
print(first_store.remove_item("tomatoes", 1))
print(second_store.remove_item("jeans", 1))
