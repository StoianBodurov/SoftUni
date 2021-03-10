class Zoo:
    def __init__(self, name, budget, animal_capacity, workers_capacity):
        self.__animal_capacity = animal_capacity
        self.__workers_capacity = workers_capacity
        self.name = name
        self.__budget = budget
        self.animals = []
        self.workers = []

    def add_animal(self, animal, price):
        if len(self.animals) == self.__animal_capacity:
            return 'Not enough space for animal'

        if self.__budget < price:
            return 'Not enough budget'

        self.animals.append(animal)
        self.__budget -= price
        return f"{animal.name} the {animal.type} added to the zoo"

    def hire_worker(self, worker):
        if len(self.workers) == self.__workers_capacity:
            return 'Not enough space for worker'

        self.workers.append(worker)
        return f'{worker.name} the {worker.type} hired successfully'

    def fire_worker(self, worker_name):
        filtered_workers = [w for w in self.workers if w.name == worker_name]
        if not filtered_workers:
            return f'There is no {worker_name} in the zoo'

        for worker in filtered_workers:
            self.workers.remove(worker)
        return f"{worker_name} fired successfully"

    def pay_workers(self):
        sum_of_salary = sum([w.salary for w in self.workers])
        if self.__budget < sum_of_salary:
            return 'You have no budget to pay your workers. They are unhappy'

        self.__budget -= sum_of_salary
        return f'You payed your workers. They are happy. Budget left: {self.__budget}'

    def tend_animals(self):
        sum_animals_need = sum([a.get_needs for a in self.animals])
        if self.__budget < sum_animals_need:
            return 'You have no budget to tend the animals. They are unhappy.'

        self.__budget -= sum_animals_need
        return f'You tended all the animals. They are happy. Budget left: {self.__budget}'

    def profit(self, amount):
        self.__budget += amount

    def animals_status(self):
        lions = [str(a) for a in self.animals if a.type == 'Lion']
        tigers = [str(a) for a in self.animals if a.type == 'Tiger']
        cheetahs = [str(a) for a in self.animals if a.type == 'Cheetah']
        to_str_lions = '\n'.join(lions)
        to_str_tigers = '\n'.join(tigers)
        to_str_cheetahs = '\n'.join(cheetahs)

        return f"You have {len(self.animals)} animals\n----- {len(lions)} Lions:\n{to_str_lions}" \
               f"\n----- {len(tigers)} Tigers:\n{to_str_tigers}\n----- {len(cheetahs)} Cheetahs:\n{to_str_cheetahs}"

    def workers_status(self):
        keepers = [str(w) for w in self.workers if w.type == 'Keeper']
        caretakers = [str(w) for w in self.workers if w.type == 'Caretaker']
        vets = [str(w) for w in self.workers if w.type == 'Vet']
        to_str_keepers = '\n'.join(keepers)
        to_str_caretakers = '\n'.join(caretakers)
        to_str_vets = '\n'.join(vets)

        return f'You have {len(self.workers)} workers\n----- {len(keepers)} Keepers:' \
               f'\n{to_str_keepers}\n----- {len(caretakers)} Caretakers:\n{to_str_caretakers}' \
               f'\n----- {len(vets)} Vets:\n{to_str_vets}'
