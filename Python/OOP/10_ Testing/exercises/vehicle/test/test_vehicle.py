from unittest import TestCase, main

from project.vehicle import Vehicle


class VehicleTest(TestCase):
    fuel = 10
    horse_power = 50

    def setUp(self):
        self.vehicle = Vehicle(self.fuel, self.horse_power)

    def test_init(self):
        self.assertEqual(self.fuel, self.vehicle.fuel)
        self.assertEqual(self.horse_power, self.vehicle.horse_power)
        self.assertEqual(self.fuel, self.vehicle.capacity)
        self.assertEqual(1.25, self.vehicle.fuel_consumption)

    def test_drive_if_not_enough_fuel_expect_exception(self):
        with self.assertRaises(Exception) as ex:
            self.vehicle.drive(10)

        self.assertEqual('Not enough fuel', str(ex.exception))

    def test_drive_if_enough_fuel_expect_return_fuel(self):
        self.vehicle.drive(1)
        self.assertEqual(8.75, self.vehicle.fuel)

    def test_refuel_if_fuel_more_than_fuel_capacity_expect_exception(self):
        with self.assertRaises(Exception) as ex:
            self.vehicle.refuel(self.fuel * 2)

        self.assertEqual('Too much fuel', str(ex.exception))

    def test_refuel_if_fuel_less_than_fuel_capacity_expect_refuel(self):
        self.vehicle.drive(8)
        self.assertEqual(0, self.vehicle.fuel)
        self.vehicle.refuel(10)
        self.assertEqual(10, self.vehicle.fuel)

    def test_str_return_correct_string(self):
        self.assertEqual(f'The vehicle has {self.horse_power} horse power with {self.fuel} fuel left and 1.25 fuel consumption', str(self.vehicle))


if __name__ == '__main__':
    main()