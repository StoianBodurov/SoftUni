from abc import ABC, abstractmethod


class Vehicle(ABC):
    def __init__(self, fuel_quantity, fuel_consumption):
        self.fuel_quantity = fuel_quantity
        self.fuel_consumption = fuel_consumption

    @abstractmethod
    def drive(self):
        pass

    @abstractmethod
    def refuel(self):
        pass


class Car(Vehicle):
    SUMMER_FUEL_CONSUMTION = 0.9

    def drive(self, distance):
        nееded_fuel = (self.fuel_consumption * distance) + (distance * Car.SUMMER_FUEL_CONSUMTION)
        if nееded_fuel <= self.fuel_quantity:
            self.fuel_quantity -= nееded_fuel

    def refuel(self, fuel):
        self.fuel_quantity += fuel


class Truck(Vehicle):
    SUMMER_FUEL_CONSUMTION = 1.6
    MAX_REFUEL = 0.95

    def drive(self, distance):
        nееded_fuel = (self.fuel_consumption * distance) + (distance * Truck.SUMMER_FUEL_CONSUMTION)
        if nееded_fuel <= self.fuel_quantity:
            self.fuel_quantity -= nееded_fuel

    def refuel(self, fuel):
        self.fuel_quantity += fuel * Truck.MAX_REFUEL
