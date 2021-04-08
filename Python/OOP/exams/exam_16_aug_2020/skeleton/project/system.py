from project.hardware.power_hardware import PowerHardware
from project.hardware.heavy_hardware import HeavyHardware
from project.software.express_software import ExpressSoftware
from project.software.light_software import LightSoftware


class System:
    _hardware = []
    _software = []

    @staticmethod
    def register_power_hardware(name, capacity, memory):
        System._hardware.append(PowerHardware(name, capacity, memory))

    @staticmethod
    def register_heavy_hardware(name, capacity, memory):
        System._hardware.append(HeavyHardware(name, capacity, memory))

    @staticmethod
    def register_express_software(hardware_name, name, capacity_consumption, memory_consumption):
        try:
            hardware = [h for h in System._hardware if h.name == hardware_name][0]
            software = ExpressSoftware(name, capacity_consumption, memory_consumption)
            hardware.install(software)
            System._software.append(software)
        except IndexError:
            return 'Hardware does not exist'

        except Exception as ex:
            return str(ex)


    @staticmethod
    def register_light_software(hardware_name, name, capacity_consumption, memory_consumption):
        try:
            hardware = [h for h in System._hardware if h.name == hardware_name][0]
            software = LightSoftware(name, capacity_consumption, memory_consumption)
            hardware.install(software)
            System._software.append(software)
        except IndexError:
            return 'Hardware does not exist'

        except Exception as ex:
            return str(ex)

    @staticmethod
    def release_software_component(hardware_name, software_name):
        try:
            hardware = [h for h in System._hardware if h.name == hardware_name][0]
            software = [s for s in System._software if s.name == software_name][0]
            hardware.uninstall(software)
            System._software.remove(software)
        except IndexError:
            return 'Some of the components do not exist'

    @staticmethod
    def analyze():
        count_of_hardware_components = len(System._hardware)
        count_of_software_components = len(System._software)
        total_used_memory = sum([s.memory_consumption for s in System._software])
        total_memory = sum([h.memory for h in System._hardware])
        total_used_space = sum([s.capacity_consumption for s in System._software])
        total_capacity = sum([h.capacity for h in System._hardware])
        return f'System Analysis\nHardware Components: {count_of_hardware_components}\n' \
               f'Software Components: {count_of_software_components}\nTotal Operational Memory: {total_used_memory} / {total_memory}\n' \
               f'Total Capacity Taken: {total_used_space} / {total_capacity}'


    @staticmethod
    def system_split():
        result = ''
        for hardware in System._hardware:
            component_name = hardware.name
            number_express_software_components = len([s for s in hardware.software_components if s.type == 'Express'])
            number_light_software_components = len([s for s in hardware.software_components if s.type == 'Light'])
            memory_usage = sum([s.memory_consumption for s in hardware.software_components])
            capacity_usage = sum([s.capacity_consumption for s in hardware.software_components])
            software_components_name = ', '.join([h.name for h in hardware.software_components])

            result += f'Hardware Component - {component_name}\nExpress Software Components: {number_express_software_components}\nLight Software Components: {number_light_software_components}\n' \
                   f'Memory Usage: {memory_usage} / {hardware.memory}\n' \
                   f'Capacity Usage: {capacity_usage} / {hardware.capacity}\nType: {hardware.type}\n' \
                   f'Software Components: {software_components_name}'
        return result




System.register_power_hardware("HDD", 200, 200)
System.register_heavy_hardware("SSD", 400, 400)
print(System.analyze())
System.register_light_software("HDD", "Test", 0, 10)
print(System.register_express_software("HDD", "Test2", 100, 100))
System.register_express_software("HDD", "Test3", 50, 100)
System.register_light_software("SSD", "Windows", 20, 50)
System.register_express_software("SSD", "Linux", 50, 100)
System.register_light_software("SSD", "Unix", 20, 50)
print(System.analyze())
System.release_software_component("SSD", "Linux")
print(System.system_split())
