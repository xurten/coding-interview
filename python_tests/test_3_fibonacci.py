# Task 3
# Write a program to calculate fibonacci

# Implementation
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
def test_fibonacci_recursive_small():
    n = 7
    expected_value = 13
    assert get_fibonacci_recursive(n) == expected_value


def test_fibonacci_recursive_bigger():
    n = 20
    expected_value = 6765
    assert get_fibonacci_recursive(n) == expected_value


def test_fibonacci_iterative_small():
    n = 7
    expected_value = 13
    assert get_fibonacci_iterative(n) == expected_value


def test_fibonacci_iterative_bigger():
    n = 20
    expected_value = 6765
    assert get_fibonacci_iterative(n) == expected_value
