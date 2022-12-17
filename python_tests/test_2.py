# Task 2
# Write a program to display the list of even numbers.

# Implementation
def get_even_numbers(n: int) -> []:
    even_number_list = filter(lambda x: x % 2 == 0, range(1, n))
    return list(even_number_list)


# Test Section
def test_even_numbers_10():
    n = 10
    expected_list = [2, 4, 6, 8]
    assert get_even_numbers(n) == expected_list


def test_even_numbers_20():
    n = 20
    expected_list = [2, 4, 6, 8, 10, 12, 14, 16, 18]
    assert get_even_numbers(n) == expected_list
