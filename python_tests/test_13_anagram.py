# Task 13
# Write a program to check if two strings are anagrams.

def is_anagram(first_string: str, second_string: str) -> bool:
    if len(first_string) != len(second_string):
        return False
    else:
        first_string = first_string.lower()
        second_string = second_string.lower()
        for letter in first_string:
            if letter not in second_string:
                return False
        return True


def test_is_anagram():
    first_string = "silent"
    second_string = "listen"
    assert is_anagram(first_string, second_string) == True


def test_is_not_anagram():
    first_string = "silent"
    second_string = "listens"
    assert is_anagram(first_string, second_string) == False