# Task 10
# Implement a function to sort a list in ascending order.

def sort_list(numbers):
    return sorted(numbers)


def test_sort_list():
    numbers = [5, 4, 3, 2, 1]
    assert sort_list(numbers) == [1, 2, 3, 4, 5]