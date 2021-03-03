class Smartphone:
    def __init__(self, memory):
        self.memory = memory
        self.used_memory = 0
        self.apps = []
        self.is_on = False

    def power(self):
        if self.is_on:
            self.is_on = False
        else:
            self.is_on = True

    def install(self, app, app_memory):
        if self.memory_left() < app_memory:
            return f'Not enough memory to install {app}'
        if not self.is_on:
            return f'Turn on your phone to install {app}'
        self.apps.append(app)
        self.used_memory += app_memory
        return f'Installing {app}'

    def memory_left(self):
        return self.memory - self.used_memory

    def status(self):
        total_apps_count = len(self.apps)
        return f'Total apps: {total_apps_count}. Memory left: {self.memory_left()}'
