# Task 3
# Write a program to calculate fibonacci

# Implementation
import pytest


def get_fibonacci_recursive(n: int) -> int:
    if n == 0:
        return 0
    elif n == 1:
        return 1
    else:
        return get_fibonacci_recursive(n - 1) + get_fibonacci_recursive(n - 2)


def get_fibonacci_iterative(n: int) -> int:
    fibonacci_first, fibonacci_second = 0, 1
    for i in range(1, n + 1):
        fibonacci_first, fibonacci_second = fibonacci_second, fibonacci_first + fibonacci_second
    return fibonacci_first


# Test Section
@pytest.mark.parametrize("n, expected_value", [(7, 13), (20, 6765)])
def test_fibonacci_recursive(n, expected_value):
    assert get_fibonacci_recursive(n) == expected_value


@pytest.mark.parametrize("n, expected_value", [(7, 13), (20, 6765)])
def test_fibonacci_iterative(n, expected_value):
    assert get_fibonacci_iterative(n) == expected_value
