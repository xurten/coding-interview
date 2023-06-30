# Task 8
# Write a program to find the maximum number in a list.


def find_max(numbers):
    max = numbers[0]
    for number in numbers:
        if number > max:
            max = number
    return max


def test_find_max():
    numbers = [1, 2, 3, 4, 5]
    assert find_max(numbers) == 5