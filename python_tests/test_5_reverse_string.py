# Task 5
# Write a program to reverse a string
import pytest


def reverse_string(message):
    if not message:
        raise Exception("String cannot be empty")
    if not message.isascii():
        raise Exception("String cannot be digits or other special characters")
    tmp = message.split(" ")
    return " ".join(tmp[::-1])


def test_reverse_string():
    input_string = "How are you?"
    expected_value = "you? are How"
    assert reverse_string(input_string) == expected_value


def test_reverse_string_empty():
    input_string = ""
    with pytest.raises(Exception):
        reverse_string(input_string)


def test_reverse_string_with_bool():
    message = True
    with pytest.raises(Exception):
        reverse_string(message)
