# Task 9
# Create a function to remove duplicates from a list.
def remove_duplicates(numbers):
    unique_numbers = []
    for number in numbers:
        if number not in unique_numbers:
            unique_numbers.append(number)
    return unique_numbers


def test_remove_duplicates():
    numbers = [1, 2, 3, 4, 5, 1, 2, 3]
    assert remove_duplicates(numbers) == [1, 2, 3, 4, 5]
