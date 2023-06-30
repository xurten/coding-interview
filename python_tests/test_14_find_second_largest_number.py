# Task 14
# Write a program to find the second largest number in a list.
import pytest


def find_second_largest(numbers):
    max = numbers[0]
    second_max = numbers[0]
    for number in numbers:
        if number > max:
            max = number
    for number in numbers:
        if second_max < number < max:
            second_max = number
    return second_max


def test_find_second_largest():
    numbers = [1, 2, 3, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5]
    assert find_second_largest(numbers) == 4
