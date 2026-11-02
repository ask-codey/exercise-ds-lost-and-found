# Tries the desk on eight items. Run it with: python demo.py
from lost_and_found import Desk

items = [("Red Umbrella", "Other"), ("Math Textbook", "Books"), ("Left Mitten", "Clothing"),
         ("Green Water Bottle", "Bottles"), ("Bike Helmet", "Sports"), ("Phone Charger", "Other"),
         ("Blue Water Bottle", "Bottles"), ("Soccer Ball", "Sports")]

desk = Desk()
for item, kind in items:
    desk.add(item, kind)

for item, kind in [("Blue Water Bottle", "Bottles"), ("Purple Scarf", "Clothing")]:
    before = desk.looks
    answer = "yes" if desk.find(item, kind) else "no"
    print(f"{item} ({kind}): {answer}, looks: {desk.looks - before}")
print(f"Tag 6: {desk.item_with_tag(6)}")
