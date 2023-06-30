# Task 12
# Implement a function to find the largest palindrome in a given string.

def find_largest_palindrome(message):
    if not message:
        raise Exception("String cannot be empty")
    if not message.isascii():
        raise Exception("String cannot be digits or other special characters")
    tmp = message.split(" ")
    return max(tmp, key=len)


def test_find_largest_palindrome():
    input_string = "How are you?"
    expected_value = "How"
    assert find_largest_palindrome(input_string) == expected_value