# The tests for the lost-and-found desk. You don't need to change this file.
# Each message says what was expected, so a failing test tells you what to look at.
from lost_and_found import Desk

ITEMS = [("Red Umbrella", "Other"), ("Math Textbook", "Books"), ("Left Mitten", "Clothing"),
         ("Green Water Bottle", "Bottles"), ("Bike Helmet", "Sports"), ("Phone Charger", "Other"),
         ("Blue Water Bottle", "Bottles"), ("Soccer Ball", "Sports")]

# The lunch line: 800 items, 100 of each of 8 kinds, handed in all mixed up.
KINDS = ["Bottles", "Books", "Clothing", "Sports", "Electronics", "Lunch Boxes", "Umbrellas", "Other"]
NAMES = ["Water Bottle", "Textbook", "Hoodie", "Soccer Ball", "Phone Charger", "Lunch Box", "Umbrella", "Key Ring"]
LIMIT = 120


def small_desk():
    desk = Desk()
    for item, kind in ITEMS:
        desk.add(item, kind)
    return desk


def big_desk():
    desk = Desk()
    for i in range(800):
        desk.add(f"{NAMES[i % 8]} {i // 8 + 1}", KINDS[i % 8])
    return desk


def ask(desk, item, kind):
    before = desk.looks
    found = desk.find(item, kind)
    return found, desk.looks - before


def test_find_says_whether_the_desk_has_it():
    desk = small_desk()
    assert desk.find("Blue Water Bottle", "Bottles") is True, "Not yet: a Blue Water Bottle was handed in, so the desk has it."
    assert desk.find("Left Mitten", "Clothing") is True, "Not yet: a Left Mitten was handed in, so the desk has it."
    assert desk.find("Purple Scarf", "Clothing") is False, "Not yet: nobody handed in a Purple Scarf."
    assert desk.find("Yo-yo", "Toys") is False, "Not yet: nothing of the kind Toys was handed in."


def test_find_counts_its_looks():
    desk = small_desk()
    found, looks = ask(desk, "Blue Water Bottle", "Bottles")
    assert found and looks >= 1, "Not yet: finding the Blue Water Bottle means looking at it, so looks should go up by at least 1."


def test_item_with_tag_gives_the_items_in_the_order_they_came_in():
    desk = small_desk()
    assert desk.item_with_tag(0) == "Red Umbrella", "Not yet: tag 0 is the first item handed in, the Red Umbrella."
    assert desk.item_with_tag(6) == "Blue Water Bottle", "Not yet: tag 6 is the seventh item handed in, the Blue Water Bottle."


def test_item_with_tag_says_empty_for_a_tag_nobody_has():
    desk = small_desk()
    assert desk.item_with_tag(8) == "empty", "Not yet: 8 items came in, tagged 0 to 7, so tag 8 is \"empty\"."
    assert desk.item_with_tag(-1) == "empty", "Not yet: there's no tag -1, so it's \"empty\"."


def test_every_student_in_the_lunch_line_gets_an_answer_in_120_looks_or_fewer():
    desk = big_desk()
    for i in range(800):
        item = f"{NAMES[i % 8]} {i // 8 + 1}"
        found, looks = ask(desk, item, KINDS[i % 8])
        assert found, f"Not yet: {item} was handed in, so the desk has it."
        assert looks <= LIMIT, f"Not yet: finding {item} took {looks} looks. The lunch line needs {LIMIT} or fewer, even with 800 items."


def test_a_missing_item_is_answered_in_120_looks_or_fewer():
    desk = big_desk()
    for kind in KINDS:
        found, looks = ask(desk, "Purple Scarf", kind)
        assert not found, "Not yet: nobody handed in a Purple Scarf."
        assert looks <= LIMIT, f"Not yet: saying no to a Purple Scarf ({kind}) took {looks} looks. The lunch line needs {LIMIT} or fewer."


def test_tags_still_work_with_800_items():
    desk = big_desk()
    assert desk.item_with_tag(0) == "Water Bottle 1", "Not yet: tag 0 is the first item handed in, Water Bottle 1."
    assert desk.item_with_tag(799) == "Key Ring 100", "Not yet: tag 799 is the last item handed in, Key Ring 100."
    assert desk.item_with_tag(800) == "empty", "Not yet: 800 items came in, tagged 0 to 799, so tag 800 is \"empty\"."
