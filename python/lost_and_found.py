# Your three functions. The comment under each one says what it should
# return, with examples. Replace each return line with your own code.


def looks_in_box(box, wanted):
    """
    The lost-and-found box: everything in one jumbled pile. Look at the
    items one at a time, from the first, until you find the one you want.
    Return how many items you looked at. If it isn't in the box, you
    looked at every item. An empty box takes 0 looks.

    looks_in_box(["Red Umbrella", "Left Mitten", "Soccer Ball"], "Left Mitten") -> 2
    looks_in_box(["Red Umbrella", "Left Mitten", "Soccer Ball"], "Purple Scarf") -> 3
    """
    return 0


def looks_on_shelf(shelves, shelf, wanted):
    """
    The labeled shelves: the same things, sorted onto shelves by kind
    ("Bottles", "Books"...). Look only on the shelf you're told, one item
    at a time from the first, and return how many items you looked at.
    If the item isn't on that shelf, you looked at the whole shelf.
    If there's no shelf with that name, there was nothing to look at: 0.

    looks_on_shelf(shelves, "Bottles", "Blue Water Bottle") -> 2
    looks_on_shelf(shelves, "Toys", "Yo-yo") -> 0
    """
    return 0


def item_in_cubby(cubbies, number):
    """
    The cubbies: one item in each numbered cubby, numbered from 0.
    Return what's in cubby number `number`, in one step: no looking
    through the others. If there's no cubby with that number, return
    "empty".

    item_in_cubby(["Red Umbrella", "Left Mitten"], 1) -> "Left Mitten"
    item_in_cubby(["Red Umbrella", "Left Mitten"], 5) -> "empty"
    """
    return ""
