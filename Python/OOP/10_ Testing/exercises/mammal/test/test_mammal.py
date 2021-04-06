from unittest import TestCase, main

from project.mammal import Mammal


class MammalTest(TestCase):
    name = 'name'
    type = 'mammal_type'
    sound = 'sound'

    def setUp(self):
        self.mammal = Mammal(self.name, self.type, self.sound)

    def test_init(self):
        self.assertEqual(self.name, self.mammal.name)
        self.assertEqual(self.type, self.mammal.type)
        self.assertEqual(self.sound, self.mammal.sound)

    def test_get_kingdom_except_return_kingdom(self):
        self.assertEqual('animals', self.mammal.get_kingdom())

    def test_info_except_return_info_str(self):
        self.assertEqual(f"{self.name} is of type {self.type}", self.mammal.info())

    def test_make_sound_except_return_str(self):
        self.assertEqual(f"{self.name} makes {self.sound}", self.mammal.make_sound())


if __name__ == '__main__':
    main()