# Task 11
# Create a function to count the occurrence of a specific element in a list.

def count_element_in_list(numbers, element):
    count = 0
    for number in numbers:
        if number == element:
            count += 1
    return count


def test_count_element_in_list():
    numbers = [1, 2, 3, 4, 5, 1, 2, 3]
    assert count_element_in_list(numbers, 1) == 2
    assert count_element_in_list(numbers, 2) == 2
    assert count_element_in_list(numbers, 3) == 2
    assert count_element_in_list(numbers, 4) == 1
    assert count_element_in_list(numbers, 5) == 1
    assert count_element_in_list(numbers, 6) == 0

