from pyfiglet import figlet_format


def print_art(txt):
    ascii_art = figlet_format(txt)
    print(ascii_art)


text = input()
print_art(text)