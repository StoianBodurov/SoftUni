class PhotoAlbum:
    def __init__(self, pages):
        self.pages = pages
        self.photos = [[] for _ in range(self.pages)]

    def __repr(self):
        pass

    @classmethod
    def from_photos_count(cls, photos_count):
        return cls(photos_count // 4)

    def add_photo(self, label):
        for page in range(len(self.photos)):
            if len(self.photos[page]) < 4:
                self.photos[page].append(label)
                slot = self.photos[page].index(label)
                return f'{label} photo added successfully on\
                page {page + 1} slot {slot + 1}'
        return 'No more free spots'

    def display(self):
        result = '\n-----------\n'.join(['[] ' * len(page) if len(page) > 0 else '\n' for page in self.photos]).rstrip()
        return f'-----------\n{result}\n-----------\n'
