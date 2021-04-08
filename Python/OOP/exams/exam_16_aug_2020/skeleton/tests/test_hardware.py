from unittest import TestCase, main

from project.hardware.hardware import Hardware
from project.software.software import Software


class HardwareTest(TestCase):
    name = 'name'
    type = 'class_type'
    capacity = 15
    memory = 10

    def setUp(self):
        self.hardware = Hardware(self.name, self.type, self.capacity, self.memory)

    def test_init(self):
        self.assertEqual(self.name, self.hardware.name)
        self.assertEqual(self.type, self.hardware.type)
        self.assertEqual(self.capacity, self.hardware.capacity)
        self.assertEqual(self.memory, self.hardware.memory)

    def test_install_when_capacity_and_memory_is_enough_successfully_added_in_software_components(self):
        software = Software('software', 'Type', 10, 8)
        self.hardware.install(software)
        self.assertIn(software, self.hardware.software_components)

    def test_install_when_capacity_is_not_enough_expect_exception(self):
        with self.assertRaises(Exception) as ex:
            software = Software('software', 'Type', 17, 8)
            self.hardware.install(software)

        self.assertEqual('Software cannot be installed', str(ex.exception))

    def test_install_when_memory_is_not_enough_expect_exception(self):
        with self.assertRaises(Exception) as ex:
            software = Software('software', 'Type', 10, 12)
            self.hardware.install(software)

        self.assertEqual('Software cannot be installed', str(ex.exception))

    def test_uninstall_remove_software(self):
        software = Software('software', 'Type', 10, 8)
        self.hardware.install(software)
        self.assertIn(software, self.hardware.software_components)
        self.hardware.uninstall(software)
        self.assertIsNot(software, self.hardware.software_components)


if __name__ == '__main__':
    main()