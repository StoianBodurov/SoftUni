from unittest import TestCase, main

from car_manager.car_manager import Car


class CarTest(TestCase):
    make = 'make'
    model = 'model'
    fuel_consumption = 10
    fuel_capacity = 100

    def setUp(self):
        self.car = Car(self.make, self.model, self.fuel_consumption, self.fuel_capacity)

    def test_make_setter_when_none_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.make = None
        self.assertEqual("Make cannot be null or empty!", str(content.exception))

    def test_model_setter_when_none_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.model = None
        self.assertEqual("Model cannot be null or empty!", str(content.exception))

    def test_fuel_consumption_setter_when_0_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.fuel_consumption = 0
        self.assertEqual("Fuel consumption cannot be zero or negative!", str(content.exception))

    def test_fuel_consumption_setter_when_negative_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.fuel_consumption = -1
        self.assertEqual("Fuel consumption cannot be zero or negative!", str(content.exception))

    def test_fuel_capacity_setter_when_negative_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.fuel_capacity = -1
        self.assertEqual("Fuel capacity cannot be zero or negative!", str(content.exception))

    def test_fuel_capacity_setter_when_0_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.fuel_capacity = 0
        self.assertEqual("Fuel capacity cannot be zero or negative!", str(content.exception))

    def test_fuel_amount_setter_when_negative_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.fuel_amount = -1
        self.assertEqual("Fuel amount cannot be negative!", str(content.exception))

    def test_refuel_when_fuel_is_0_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.refuel(0)
        self.assertEqual('Fuel amount cannot be zero or negative!', str(content.exception))

    def test_refuel_when_fuel_is_negative_expect_exception(self):
        with self.assertRaises(Exception) as content:
            self.car.refuel(-1)
        self.assertEqual('Fuel amount cannot be zero or negative!', str(content.exception))

    def test_refuel_when_fuel_amount_bigger_from_fuel_capacity(self):
        self.car.refuel(self.fuel_capacity * 2)
        self.assertEqual(self.car.fuel_capacity, self.car.fuel_amount)

    def test_refuel_when_fuel_amount_small_from_fuel_capacity(self):
        self.car.refuel(50)
        self.assertEqual(50, self.car.fuel_amount)

    def test_drive_when_distance_is_bigger_than_needed_fuel_amount_expect_exception(self):
        self.car.refuel(10)
        with self.assertRaises(Exception) as content:
            self.car.drive(110)
        self.assertEqual('You don\'t have enough fuel to drive!', str(content.exception))


if __name__ == '__main__':
    main()