import math
from abc import ABC, abstractmethod


class Shapes(ABC):

    @abstractmethod
    def calculate_area(self):
        pass

    @abstractmethod
    def calculate_perimeter(self):
        pass


class Circle(Shapes):
    def __init__(self, radius):
        self.__radius = radius

    def calculate_area(self):
        return math.pi * self.__radius * self.__radius

    def calculate_perimeter(self):
        return math.pi * self.__radius * 2


class Rectangle(Shapes):
    def __init__(self, height, width ):
        self.__height = height
        self.__width = width

    def calculate_area(self):
        return self.__width * self.__height

    def calculate_perimeter(self):
        return (self.__width + self.__height) * 2


rectangle = Rectangle(10, 20)
print(rectangle.calculate_area())
print(rectangle.calculate_perimeter())
circle = Circle(5)
print(circle.calculate_area())
print(circle.calculate_perimeter())
