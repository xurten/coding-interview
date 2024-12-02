# Description:
# Implement a Python function that checks the order of the elements in a list. The function should return:

# 1 if the list is strictly increasing,
# -1 if the list is strictly decreasing,
# 0 if the list is constant or contains mixed order elements.

def check_list_order(lst):
    if not lst or len(lst) < 2:
        return 0

    is_increasing = True
    is_decreasing = True

    for i in range(1, len(lst)):
        if lst[i] < lst[i - 1]:
            is_increasing = False
        elif lst[i] > lst[i - 1]:
            is_decreasing = False
        else:
            is_increasing = False
            is_decreasing = False

    if is_increasing:
        return 1
    elif is_decreasing:
        return -1
    else:
        return 0


def check_list_order_with_sorted(lst):
    if not lst or len(lst) < 2:
        return 0

    sorted_asc = sorted(lst)
    sorted_desc = sorted(lst, reverse=True)

    if lst == sorted_asc and len(set(lst)) == len(lst):
        return 1
    elif lst == sorted_desc and len(set(lst)) == len(lst):
        return -1
    else:
        return 0


def test_lists():
    assert check_list_order([1, 2, 3, 4]) == 1, "Expected 1 for strictly increasing list [1, 2, 3, 4]"
    assert check_list_order([4, 3, 2, 1]) == -1, "Expected -1 for strictly decreasing list [4, 3, 2, 1]"
    assert check_list_order([1, 1, 1, 1]) == 0, "Expected 0 for constant list [1, 1, 1, 1]"
    assert check_list_order([1, 3, 2, 4]) == 0, "Expected 0 for mixed order list [1, 3, 2, 4]"
    assert check_list_order([]) == 0, "Expected 0 for empty list []"
    assert check_list_order([5]) == 0, "Expected 0 for single element list [5]"

    assert check_list_order_with_sorted([1, 2, 3, 4]) == 1, "Expected 1 for strictly increasing list [1, 2, 3, 4]"
    assert check_list_order_with_sorted([4, 3, 2, 1]) == -1, "Expected -1 for strictly decreasing list [4, 3, 2, 1]"
    assert check_list_order_with_sorted([1, 1, 1, 1]) == 0, "Expected 0 for constant list [1, 1, 1, 1]"
    assert check_list_order_with_sorted([1, 3, 2, 4]) == 0, "Expected 0 for mixed order list [1, 3, 2, 4]"
    assert check_list_order_with_sorted([]) == 0, "Expected 0 for empty list []"
    assert check_list_order_with_sorted([5]) == 0, "Expected 0 for single element list [5]"