class Circle:
    pi = 3.14

    def __init__(self, radius):
        self.radius = radius

    def set_radius(self, new_radius):
        self.radius = new_radius

    def get_area(self):
        area = Circle.pi * self.radius ** 2
        return area

    def get_circumference(self):
        circumference = Circle.pi * self.radius * 2
        return circumference