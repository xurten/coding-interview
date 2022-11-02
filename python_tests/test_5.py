import pytest


def reverse_string(input):
    if not input:
        raise Exception("String cannot be empty")
    if not input.isascii():
        raise Exception("String cannot be digits or other special characters")
    tmp = input.split(" ")
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
    input_string = True
    with pytest.raises(Exception):
        reverse_string(input_string)