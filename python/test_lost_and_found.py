# The tests for your three functions. You don't need to change this file.
# Each message says what was expected, so a failing test tells you what to look at.
from lost_and_found import item_in_cubby, looks_in_box, looks_on_shelf

BOX = ["Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball"]
SHELVES = {
    "Bottles": ["Green Water Bottle", "Blue Water Bottle"],
    "Books": ["Math Textbook"],
    "Clothing": ["Left Mitten"],
    "Sports": ["Bike Helmet", "Soccer Ball"],
    "Other": ["Red Umbrella", "Phone Charger"],
}


def test_looks_in_box_finds_the_first_item_in_one_look():
    assert looks_in_box(BOX, "Red Umbrella") == 1, "Not yet: Red Umbrella is the first item, so it takes 1 look."


def test_looks_in_box_counts_every_item_up_to_the_one_you_want():
    assert looks_in_box(BOX, "Left Mitten") == 3, "Not yet: Left Mitten is the third item, so it takes 3 looks."
    assert looks_in_box(BOX, "Blue Water Bottle") == 7, "Not yet: Blue Water Bottle is the seventh item, so it takes 7 looks."


def test_looks_in_box_looks_at_everything_when_the_item_is_missing():
    assert looks_in_box(BOX, "Purple Scarf") == 8, "Not yet: Purple Scarf isn't in the box, so you look at all 8 items."
    assert looks_in_box([], "Purple Scarf") == 0, "Not yet: an empty box takes 0 looks."


def test_looks_on_shelf_looks_only_on_that_shelf():
    assert looks_on_shelf(SHELVES, "Bottles", "Blue Water Bottle") == 2, \
        "Not yet: Blue Water Bottle is second on the Bottles shelf, so it takes 2 looks."
    assert looks_on_shelf(SHELVES, "Sports", "Soccer Ball") == 2, \
        "Not yet: Soccer Ball is second on the Sports shelf, so it takes 2 looks."


def test_looks_on_shelf_looks_at_the_whole_shelf_when_the_item_is_missing():
    assert looks_on_shelf(SHELVES, "Books", "Science Textbook") == 1, \
        "Not yet: the Books shelf holds 1 item, so a missing book takes 1 look."
    assert looks_on_shelf(SHELVES, "Toys", "Yo-yo") == 0, "Not yet: there's no Toys shelf, so there's nothing to look at: 0 looks."


def test_item_in_cubby_gives_whats_in_that_cubby():
    assert item_in_cubby(BOX, 6) == "Blue Water Bottle", "Not yet: cubby 6 holds Blue Water Bottle (cubbies are numbered from 0)."
    assert item_in_cubby(BOX, 0) == "Red Umbrella", "Not yet: cubby 0 is the first cubby, and it holds Red Umbrella."


def test_item_in_cubby_says_empty_for_a_number_with_no_cubby():
    assert item_in_cubby(BOX, 8) == "empty", "Not yet: the cubbies are numbered 0 to 7, so there's no cubby 8: \"empty\"."
    assert item_in_cubby(BOX, -1) == "empty", "Not yet: there's no cubby -1: \"empty\"."
