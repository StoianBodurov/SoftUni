input_password = input()


def password_validator(password):
    validator1 = False
    validator2 = False
    validator3 = False
    if not 6 <= len(password) <= 10:
        print('Password must be between 6 and 10 characters')
    else:
        validator1 = True

    if not password.isalnum():
        print('Password must consist only of letters and digits')
    else:
        validator2 = True

    digit_count = 0
    for symbol in range(0, len(password)):
        if password[symbol].isdigit():
            digit_count += 1

    if not digit_count >= 2:
        print('Password must have at least 2 digits')
    else:
        validator3 = True

    if validator1 and validator2 and validator3:
        print('Password is valid')


password_validator(input_password)
