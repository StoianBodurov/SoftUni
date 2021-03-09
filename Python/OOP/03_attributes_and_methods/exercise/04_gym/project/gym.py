class Gym:
    def __init__(self):
        self.customers = []
        self.trainers = []
        self.equipment = []
        self.plans = []
        self.subscriptions = []

    @staticmethod
    def add_object(obj, place):
        if obj not in place:
            place.append(obj)

    def add_customer(self, customer):
        self.add_object(customer, self.customers)

    def add_trainer(self, trainer):
        self.add_object(trainer, self.trainers)

    def	add_equipment(self, equipment):
        self.add_object(equipment, self.equipment)

    def add_plan(self, plan):
        self.add_object(plan, self.plans)

    def add_subscription(self, subscription):
        self.add_object(subscription, self.subscriptions)

    def subscription_info(self, subscription_id):
        subscription = [s for s in self.subscriptions if s.id == subscription_id][0]
        customer = [c for c in self.customers if subscription.customer_id == c.id][0]
        trainer = [t for t in self.trainers if subscription.trainer_id == t.id][0]
        plan = [p for p in self.plans if p.trainer_id == trainer.id][0]
        equipment = [e for e in self.equipment if e.id == plan.equipment_id][0]
        return f'{subscription}\n{customer}\n{trainer}\n{equipment}\n{plan}'
