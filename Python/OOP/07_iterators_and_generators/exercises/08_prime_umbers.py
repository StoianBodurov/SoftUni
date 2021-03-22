from math import sqrt


def get_primes(numbers):
    def is_prime(n):
        if n < 2:
            return False
        for i in range(2, int(sqrt(n)) + 1):
            if n % i == 0:
                return False
        return True

    for num in numbers:
        if is_prime(num):
            yield num


# print(list(get_primes([2, 4, 3, 5, 6, 9, 1, 0])))
# test zero
import unittest

class Tests(unittest.TestCase):
    def test_zero(self):
        res = list(get_primes([2, 4, 3, 5, 6, 9, 1, 0]))
        self.assertEqual(res, [2, 3, 5])

if __name__ == '__main__':
    unittest.main()