# Tries your functions on the lost-and-found. Run it with: python demo.py
from lost_and_found import item_in_cubby, looks_in_box, looks_on_shelf

box = ["Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball"]
shelves = {
    "Bottles": ["Green Water Bottle", "Blue Water Bottle"],
    "Books": ["Math Textbook"],
    "Clothing": ["Left Mitten"],
    "Sports": ["Bike Helmet", "Soccer Ball"],
    "Other": ["Red Umbrella", "Phone Charger"],
}
cubbies = list(box)

print("Box: " + ", ".join(box))
print(f"Looks in the box for Blue Water Bottle: {looks_in_box(box, 'Blue Water Bottle')}")
print(f"Looks on the Bottles shelf for Blue Water Bottle: {looks_on_shelf(shelves, 'Bottles', 'Blue Water Bottle')}")
print(f"Cubby 6 holds: {item_in_cubby(cubbies, 6)}")
