# Task 17
# Write a program to merge two sorted lists into a single sorted list.

def merge_sorted_lists(list1, list2):
    return sorted(list1 + list2)


def test_merge_sorted_lists():
    assert merge_sorted_lists([1, 2, 3], [4, 5, 6]) == [1, 2, 3, 4, 5, 6]

