// Tries the desk on eight items. Run it with: node demo.ts
import { Desk } from "./lost-and-found.ts";

const items: [string, string][] = [["Red Umbrella", "Other"], ["Math Textbook", "Books"], ["Left Mitten", "Clothing"],
  ["Green Water Bottle", "Bottles"], ["Bike Helmet", "Sports"], ["Phone Charger", "Other"],
  ["Blue Water Bottle", "Bottles"], ["Soccer Ball", "Sports"]];

const desk = new Desk();
for (const [item, kind] of items) {
  desk.add(item, kind);
}

const requests: [string, string][] = [["Blue Water Bottle", "Bottles"], ["Purple Scarf", "Clothing"]];
for (const [item, kind] of requests) {
  const before = desk.looks;
  const answer = desk.find(item, kind) ? "yes" : "no";
  console.log(`${item} (${kind}): ${answer}, looks: ${desk.looks - before}`);
}
console.log(`Tag 6: ${desk.itemWithTag(6)}`);
