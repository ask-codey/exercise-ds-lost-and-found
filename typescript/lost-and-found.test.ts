// The tests for your three functions. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
import assert from "node:assert/strict";
import { test } from "node:test";
import { itemInCubby, looksInBox, looksOnShelf } from "./lost-and-found.ts";

const BOX: string[] = ["Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball"];
const SHELVES: Record<string, string[]> = {
  Bottles: ["Green Water Bottle", "Blue Water Bottle"],
  Books: ["Math Textbook"],
  Clothing: ["Left Mitten"],
  Sports: ["Bike Helmet", "Soccer Ball"],
  Other: ["Red Umbrella", "Phone Charger"],
};

test("looks in box: finds the first item in one look", () => {
  assert.equal(looksInBox(BOX, "Red Umbrella"), 1, "Not yet: Red Umbrella is the first item, so it takes 1 look.");
});

test("looks in box: counts every item up to the one you want", () => {
  assert.equal(looksInBox(BOX, "Left Mitten"), 3, "Not yet: Left Mitten is the third item, so it takes 3 looks.");
  assert.equal(looksInBox(BOX, "Blue Water Bottle"), 7, "Not yet: Blue Water Bottle is the seventh item, so it takes 7 looks.");
});

test("looks in box: looks at everything when the item is missing", () => {
  assert.equal(looksInBox(BOX, "Purple Scarf"), 8, "Not yet: Purple Scarf isn't in the box, so you look at all 8 items.");
  assert.equal(looksInBox([], "Purple Scarf"), 0, "Not yet: an empty box takes 0 looks.");
});

test("looks on shelf: looks only on that shelf", () => {
  assert.equal(looksOnShelf(SHELVES, "Bottles", "Blue Water Bottle"), 2, "Not yet: Blue Water Bottle is second on the Bottles shelf, so it takes 2 looks.");
  assert.equal(looksOnShelf(SHELVES, "Sports", "Soccer Ball"), 2, "Not yet: Soccer Ball is second on the Sports shelf, so it takes 2 looks.");
});

test("looks on shelf: looks at the whole shelf when the item is missing", () => {
  assert.equal(looksOnShelf(SHELVES, "Books", "Science Textbook"), 1, "Not yet: the Books shelf holds 1 item, so a missing book takes 1 look.");
  assert.equal(looksOnShelf(SHELVES, "Toys", "Yo-yo"), 0, "Not yet: there's no Toys shelf, so there's nothing to look at: 0 looks.");
});

test("item in cubby: gives what's in that cubby", () => {
  assert.equal(itemInCubby(BOX, 6), "Blue Water Bottle", "Not yet: cubby 6 holds Blue Water Bottle (cubbies are numbered from 0).");
  assert.equal(itemInCubby(BOX, 0), "Red Umbrella", "Not yet: cubby 0 is the first cubby, and it holds Red Umbrella.");
});

test("item in cubby: says empty for a number with no cubby", () => {
  assert.equal(itemInCubby(BOX, 8), "empty", "Not yet: the cubbies are numbered 0 to 7, so there's no cubby 8: \"empty\".");
  assert.equal(itemInCubby(BOX, -1), "empty", "Not yet: there's no cubby -1: \"empty\".");
});
