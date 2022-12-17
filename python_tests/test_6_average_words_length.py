# Task 6
# Write a program calculate average words length
import string

first_sentence = "Hi all, my name is Tom...I am originally from Australia."
second_sentence = "I need to work very hard to learn more about algorithms in Python!"


def remove_special_characters(message: str) -> str:
    for letter in string.punctuation:
        message = message.replace(letter, '')
    return message


def average_words_length(message: str) -> str:
    message_without_special_characters = remove_special_characters(message)
    words_length_sum = 0
    split_message = message_without_special_characters.split(' ')
    for word in split_message:
        words_length_sum = words_length_sum + len(word)
    return round(words_length_sum / len(split_message), ndigits=2)


def test_average_words_length_with_first_message():
    assert average_words_length(first_sentence) == 4.2


def test_average_words_length_with_second_message():
    assert average_words_length(second_sentence) == 4.08
