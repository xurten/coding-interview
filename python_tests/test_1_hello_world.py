# Task 1
# Writing “Hello, World!” program.

# Implementation
def get_hello_world() -> str:
    return "Hello, World!"


# Test Section
def test_hello_world():
    expected_string = "Hello, World!"
    assert get_hello_world() == expected_string
