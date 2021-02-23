class Cup:
    def __init__(self, size, quantity):
        self.size = size
        self.quantity = quantity
        self.free_space = self.size - self.quantity
    def fill(self, milliliters):
        if milliliters <= self.free_space:
            self.quantity += milliliters
            self.free_space -= milliliters
    def status(self):
        return self.free_space