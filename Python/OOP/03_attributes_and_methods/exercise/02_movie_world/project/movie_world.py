class MovieWorld:
    def __init__(self, name):
        self.name = name
        self.customers = []
        self.dvds = []

    def __repr__(self):
        customers = '\n'.join([f"{c.id}: {c.name} of age {c.age} has {len(c.rented_dvds)} rented DVD\'s "
                               f"({''.join([dvd.name for dvd in c.rented_dvds])})" for c in self.customers])
        dvds = '\n'.join([f"{d.id}: {d.name} ({d.creation_month} {d.creation_year}) has age restriction {d.age_restriction}. Status: {['rented' if d.is_rented else 'not rented'][0]}" for d in self.dvds])
        return f'{customers}\n{dvds}'
    @staticmethod
    def dvd_capacity():
        return 15

    @staticmethod
    def customer_capacity():
        return 10

    def add_customer(self, customer):
        customer_count = len(self.customers)
        if customer_count < self.customer_capacity():
            self.customers.append(customer)

    def add_dvd(self, dvd):
        dvd_count = len(self.dvds)
        if dvd_count < self.dvd_capacity():
            self.dvds.append(dvd)

    def rent_dvd(self, customer_id, dvd_id):
        dvd = [dvd for dvd in self.dvds if dvd.id == dvd_id][0]
        customer = [c for c in self.customers if c.id == customer_id][0]
        if dvd in customer.rented_dvds:
            return f'{customer.name} has already rented {dvd.name}'

        if dvd.is_rented:
            return 'DVD is already rented'

        if customer.age < dvd.age_restriction:
            return f"{customer.name} should be at least {dvd.age_restriction} to rent this movie"

        customer.rented_dvds.append(dvd)
        dvd.is_rented = True
        return f"{customer.name} has successfully rented {dvd.name}"

    def return_dvd(self, customer_id, dvd_id):
        customer = [c for c in self.customers if c.id == customer_id][0]
        rented_dvd =[dvd.id for dvd in customer.rented_dvds]

        if dvd_id in rented_dvd:
            dvd = [d for d in customer.rented_dvds if d.id == dvd_id][0]
            customer.rented_dvds.remove(dvd)
            dvd.is_rented = False
            return f"{customer.name} has successfully returned {dvd.name}"

        return f"{customer.name} does not have that DVD"





