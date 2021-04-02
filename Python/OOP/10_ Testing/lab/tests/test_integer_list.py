from unittest import TestCase, main

from list.extended_list import IntegerList


class IntegerListTest(TestCase):
    def test_integer_list_when_add_int_expect_to_add(self):
        self.test_list = IntegerList()
        self.test_list = self.test_list.add(2)
        self.assertEqual([2], self.test_list)

    def test_integer_list_when_add_str_expect_exception(self):
        self.test_list = IntegerList()

        with self.assertRaises(ValueError):
            self.test_list.add('1')

    def test_integer_list_when_remove_index_expected_returns_it(self):
        self.test_list = IntegerList(1, 5, 6, 7)
        result = self.test_list.remove_index(3)
        self.assertEqual(7, result)

    def test_integer_list_when_remove_positive_index_out_of_rage_expected_exxeption(self):
        self.test_list = IntegerList(1, 2, 4, 5)
        with self.assertRaises(IndexError):
            self.test_list.remove_index(4)

    def test_integer_list_when_remove_negative_index_out_of_rage_expected_exception(self):
        self.test_list = IntegerList(1, 2, 4, 5)
        with self.assertRaises(IndexError):
            self.test_list.remove_index(-5)

    def test_integer_list_init_not_only_take_integer_expected_only_integer_take(self):
        self.test_list = IntegerList(1, 2, 3, 'a', 4)
        self.assertEqual([1, 2, 3, 4], self.test_list.get_data())

    def test_integer_list_get_when_valid_index_expected_to_return(self):
        self.test_list = IntegerList(1, 2, 4, 5, 6)
        self.assertEqual(4, self.test_list.get(2))

    def test_integer_list_get_when_positive_invalid_index_expected_to_return(self):
        self.test_list = IntegerList(1, 2, 4, 5, 6)
        with self.assertRaises(IndexError) as ex:
            self.test_list.get(5)

        self.assertEqual("Index is out of range", str(ex.exception))

    def test_integer_list_insert_when_valid_index_and_value_expected_to_return(self):
        self.test_list = IntegerList(1, 2, 4, 5, 6)
        self.test_list.insert(1, 8)
        self.assertEqual([1, 8, 2, 4, 5, 6], self.test_list.get_data())

    def test_integer_list_insert_when_valid_index_and_invalid_value_expected_to_return(self):
        self.test_list = IntegerList(1, 2, 4, 5, 6)
        with self.assertRaises(ValueError) as ex:
            self.test_list.insert(1, '1')

        self.assertEqual("Element is not Integer", str(ex.exception))

    def test_integer_list_insert_when_invalid_index_and_valid_value_expected_to_return(self):
        self.test_list = IntegerList(1, 2, 4, 5, 6)
        with self.assertRaises(IndexError) as ex:
            self.test_list.insert(5, 5)

        self.assertEqual("Index is out of range", str(ex.exception))

    def test_integer_list_get_biggest_expected_to_return(self):
        biggest = 18
        self.test_list = IntegerList(1, 2, biggest, 5, 8)
        self.assertEqual(biggest, self.test_list.get_biggest())

    def test_integer_list_get_index_when_index_is_valid_expected_return(self):
        self.test_list = IntegerList(1, 3, 9, 8)
        self.assertEqual(2, self.test_list.get_index(9))


if __name__ == '__main__':
    main()
