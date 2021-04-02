
import unittest

from worker.worker import Worker


class WorkerTests(unittest.TestCase):
    name = 'Worker'
    salary = 1000
    energy = 100

    def setUp(self):
        self.worker = Worker(self.name, self.salary, self.energy)

    def test_initialization_with_correct_name_salary_energy(self):
        self.assertEqual(self.name, self.worker.name)
        self.assertEqual(self.salary, self.worker.salary)
        self.assertEqual(self.energy, self.worker.energy)

    def test_if_worker_rest_energy_increment(self):
        self.worker.rest()
        self.assertEqual(self.energy + 1, self.worker.energy)

    def test_if_worker_tay_work_if_energy_equal_0(self):
        self.worker.energy = 0
        with self.assertRaises(Exception) as ex:
            self.worker.work()
        self.assertEqual('Not enough energy.', str(ex.exception))

    def test_worker_work__money_correctly_increased(self):
        self.worker.work()
        self.assertEqual(self.worker.money, self.worker.salary)

    def test_worker_work__energy_correctly_decreased(self):
        self.worker.work()
        self.assertEqual(self.energy - 1, self.worker.energy)

    def test_get_info_return_proper_string_with_correct_value(self):
        self.assertEqual(f'{self.name} has saved 0 money.', self.worker.get_info())


if __name__ == '__main__':
    unittest.main()
