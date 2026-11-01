// Tries your functions on the lost-and-found. Run it with: node demo.js
import { itemInCubby, looksInBox, looksOnShelf } from "./lost-and-found.js";

const box = ["Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball"];
const shelves = {
  Bottles: ["Green Water Bottle", "Blue Water Bottle"],
  Books: ["Math Textbook"],
  Clothing: ["Left Mitten"],
  Sports: ["Bike Helmet", "Soccer Ball"],
  Other: ["Red Umbrella", "Phone Charger"],
};
const cubbies = [...box];

console.log("Box: " + box.join(", "));
console.log(`Looks in the box for Blue Water Bottle: ${looksInBox(box, "Blue Water Bottle")}`);
console.log(`Looks on the Bottles shelf for Blue Water Bottle: ${looksOnShelf(shelves, "Bottles", "Blue Water Bottle")}`);
console.log(`Cubby 6 holds: ${itemInCubby(cubbies, 6)}`);
