# Task 15
# Implement a function to reverse a linked list.

def reverse_linked_list(linked_list):
    return linked_list[::-1]


def test_reverse_linked_list():
    test_data = [
        ([1, 2, 3, 4, 5], [5, 4, 3, 2, 1]),
        ([1, 2, 3, 4, 5, 6], [6, 5, 4, 3, 2, 1]),
        ([1], [1]),
        ([], []),
    ]
    for linked_list, expected in test_data:
        assert reverse_linked_list(linked_list) == expected