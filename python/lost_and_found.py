# The lost-and-found desk. The comment inside each method says what it
# should do, with examples. Change the code so the desk keeps up with
# the lunch line, and write each method's growth rate in its comment.


class Desk:
    def __init__(self):
        self.box = []  # every item, in the order it was handed in
        self.looks = 0  # how many items the desk has looked at, for every request so far

    def add(self, item, kind):
        """
        An item is handed in, with its kind ("Bottles", "Clothing"...). Its tag
        number is how many items were handed in before it: 0, 1, 2...

        add("Red Umbrella", "Other") -> the first item, tag 0

        Growth rate: (write it here)
        """
        self.box.append(item)

    def find(self, item, kind):
        """
        A student asks for an item by its name and its kind. Return True if
        the desk has it, False if not. Add 1 to self.looks for every item
        the desk looks at.

        find("Blue Water Bottle", "Bottles") -> True
        find("Purple Scarf", "Clothing") -> False

        Growth rate: (write it here)
        """
        for thing in self.box:
            self.looks += 1
            if thing == item:
                return True
        return False

    def item_with_tag(self, number):
        """
        A student brings the tag number from the desk's log. Return that item
        in one step, without looking through the others. Tags start at 0. If
        no item has that tag, return "empty".

        item_with_tag(0) -> "Red Umbrella"  (the first item handed in)
        item_with_tag(8) -> "empty"  (when only 8 items have come in)

        Growth rate: (write it here)
        """
        return "empty"
