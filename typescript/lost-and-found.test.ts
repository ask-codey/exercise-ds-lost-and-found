// The tests for the lost-and-found desk. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
import assert from "node:assert/strict";
import { test } from "node:test";
import { Desk } from "./lost-and-found.ts";

const ITEMS: [string, string][] = [["Red Umbrella", "Other"], ["Math Textbook", "Books"], ["Left Mitten", "Clothing"],
  ["Green Water Bottle", "Bottles"], ["Bike Helmet", "Sports"], ["Phone Charger", "Other"],
  ["Blue Water Bottle", "Bottles"], ["Soccer Ball", "Sports"]];

// The lunch line: 800 items, 100 of each of 8 kinds, handed in all mixed up.
const KINDS: string[] = ["Bottles", "Books", "Clothing", "Sports", "Electronics", "Lunch Boxes", "Umbrellas", "Other"];
const NAMES: string[] = ["Water Bottle", "Textbook", "Hoodie", "Soccer Ball", "Phone Charger", "Lunch Box", "Umbrella", "Key Ring"];
const LIMIT = 120;

function smallDesk(): Desk {
  const desk = new Desk();
  for (const [item, kind] of ITEMS) {
    desk.add(item, kind);
  }
  return desk;
}

function bigDesk(): Desk {
  const desk = new Desk();
  for (let i = 0; i < 800; i++) {
    desk.add(`${NAMES[i % 8]} ${Math.floor(i / 8) + 1}`, KINDS[i % 8]);
  }
  return desk;
}

function ask(desk: Desk, item: string, kind: string): [boolean, number] {
  const before = desk.looks;
  const found = desk.find(item, kind);
  return [found, desk.looks - before];
}

test("find: says whether the desk has it", () => {
  const desk = smallDesk();
  assert.equal(desk.find("Blue Water Bottle", "Bottles"), true, "Not yet: a Blue Water Bottle was handed in, so the desk has it.");
  assert.equal(desk.find("Left Mitten", "Clothing"), true, "Not yet: a Left Mitten was handed in, so the desk has it.");
  assert.equal(desk.find("Purple Scarf", "Clothing"), false, "Not yet: nobody handed in a Purple Scarf.");
  assert.equal(desk.find("Yo-yo", "Toys"), false, "Not yet: nothing of the kind Toys was handed in.");
});

test("find: counts its looks", () => {
  const [found, looks] = ask(smallDesk(), "Blue Water Bottle", "Bottles");
  assert.ok(found && looks >= 1, "Not yet: finding the Blue Water Bottle means looking at it, so looks should go up by at least 1.");
});

test("item with tag: gives the items in the order they came in", () => {
  const desk = smallDesk();
  assert.equal(desk.itemWithTag(0), "Red Umbrella", "Not yet: tag 0 is the first item handed in, the Red Umbrella.");
  assert.equal(desk.itemWithTag(6), "Blue Water Bottle", "Not yet: tag 6 is the seventh item handed in, the Blue Water Bottle.");
});

test("item with tag: says empty for a tag nobody has", () => {
  const desk = smallDesk();
  assert.equal(desk.itemWithTag(8), "empty", "Not yet: 8 items came in, tagged 0 to 7, so tag 8 is \"empty\".");
  assert.equal(desk.itemWithTag(-1), "empty", "Not yet: there's no tag -1, so it's \"empty\".");
});

test("the lunch line: every student gets an answer in 120 looks or fewer", () => {
  const desk = bigDesk();
  for (let i = 0; i < 800; i++) {
    const item = `${NAMES[i % 8]} ${Math.floor(i / 8) + 1}`;
    const [found, looks] = ask(desk, item, KINDS[i % 8]);
    assert.ok(found, `Not yet: ${item} was handed in, so the desk has it.`);
    assert.ok(looks <= LIMIT, `Not yet: finding ${item} took ${looks} looks. The lunch line needs ${LIMIT} or fewer, even with 800 items.`);
  }
});

test("the lunch line: a missing item is answered in 120 looks or fewer", () => {
  const desk = bigDesk();
  for (const kind of KINDS) {
    const [found, looks] = ask(desk, "Purple Scarf", kind);
    assert.ok(!found, "Not yet: nobody handed in a Purple Scarf.");
    assert.ok(looks <= LIMIT, `Not yet: saying no to a Purple Scarf (${kind}) took ${looks} looks. The lunch line needs ${LIMIT} or fewer.`);
  }
});

test("the lunch line: tags still work with 800 items", () => {
  const desk = bigDesk();
  assert.equal(desk.itemWithTag(0), "Water Bottle 1", "Not yet: tag 0 is the first item handed in, Water Bottle 1.");
  assert.equal(desk.itemWithTag(799), "Key Ring 100", "Not yet: tag 799 is the last item handed in, Key Ring 100.");
  assert.equal(desk.itemWithTag(800), "empty", "Not yet: 800 items came in, tagged 0 to 799, so tag 800 is \"empty\".");
});
