class Subscription:
    _id = 0

    def __init__(self, data, customer_id, trainer_id, exercise):
        Subscription._id += 1
        self.data = data
        self.customer_id = customer_id
        self.trainer_id = trainer_id
        self.exercise = exercise
        self.id = Subscription._id

    def __repr__(self):
        return f'Subscription <{self.id}> on {self.data}'

    @staticmethod
    def get_next_id():
        return Subscription._id + 1