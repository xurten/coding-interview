# Task 16
# Implement a function to find the sum of digits of a number.
import pytest


def sum_of_digits(number):
    sum = 0
    for digit in str(number):
        sum += int(digit)
    return sum


@pytest.mark.parametrize("number, expected_sum", [(123, 6), (1234, 10), (12345, 15)])
def test_sum_of_digits(number, expected_sum):
    assert sum_of_digits(number) == expected_sum
