class Hotel:
    def __init__(self, name):
        self.name = name
        self.rooms = []
        self.guests = 0

    @classmethod
    def from_stars(cls, stars_count):
        return cls(f'{stars_count} stars Hotel')

    @staticmethod
    def find_room(room_number, rooms):
        return [room for room in rooms if room.number == room_number][0]

    def add_room(self, room):
        self.rooms.append(room)

    def take_room(self, room_number, people):
        result = self.find_room(room_number, self.rooms).take_room(people)
        if result:
            return result

        self.guests += people

    def free_room(self, room_number):
        room = self.find_room(room_number, self.rooms)
        guests_to_remove = room.guests
        result = room.free_room()
        if result:
            return result
        self.guests -= guests_to_remove


    def print_status(self):
        free_rooms_numbers = [str(room) for room in self.rooms if not room.is_taken]
        taken_rooms_numbers = [str(room) for room in self.rooms if room.is_taken]
        print(f"Hotel {self.name} has {self.guests} total guests\nFree rooms: {', '.join(free_rooms_numbers)}\nTaken rooms: {', '.join(taken_rooms_numbers)}")