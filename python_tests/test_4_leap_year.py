# Task 4
# Write a program to determine If the given year is a Leap year.

# Implementation
import pytest


def is_leap_year(year: int) -> int:
    return year % 4 == 0 and (year % 100 != 0 or year % 400 == 0)


# Test Section
@pytest.mark.parametrize("year", [2000, 2016, 2020, 2024, 2400])
def test_is_leap_year(year):
    assert is_leap_year(year) == True


@pytest.mark.parametrize("year", [1800, 1900, 2100, 2200, 2300])
def test_is_not_leap_year(year):
    assert is_leap_year(year) == False
