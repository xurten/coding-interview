# Task 7
# Write a program to check if a number is a prime number


def is_prime(number):
    prime_status = True
    for k in range(2, round(number / 2)):
        if number % k == 0:
            prime_status = False
            break
    return prime_status


def test_prime_number():
    assert is_prime(13) == True


def test_not_prime_number():
    assert is_prime(2000) == False
