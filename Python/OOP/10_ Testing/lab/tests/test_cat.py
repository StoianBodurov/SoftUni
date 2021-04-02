import unittest

from cat.cat import Cat


class CatTests(unittest.TestCase):
    def setUp(self):
        self.cat = Cat('Test cat')

    def test_if_cat_eat_size_increased(self):
        self.cat.eat()
        self.assertEqual(1, self.cat.size)

    def test_chek_is_cat_fed_after_eating(self):
        self.cat.eat()
        self.assertTrue(self.cat.fed)

    def test_cat_cannot_eat_if_fed_raises_error(self):
        self.cat.fed = True
        with self.assertRaises(Exception) as ex:
            self.cat.eat()

        self.assertEqual('Already fed.', str(ex.exception))

    def test_cat_cannot_sleep_if_not_fed_raises_error(self):
        with self.assertRaises(Exception) as ex:
            self.cat.sleep()
        self.assertEqual('Cannot sleep while hungry', str(ex.exception))

    def test_cat_cannot_sleepy_after_sleeping(self):
        self.cat.eat()
        self.cat.sleep()
        self.assertFalse(self.cat.sleepy)


if __name__ == '__main__':
    unittest.main()