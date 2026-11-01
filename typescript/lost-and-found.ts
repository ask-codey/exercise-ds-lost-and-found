// Your three functions. The comment above each one says what it should
// return, with examples. Replace each return line with your own code.

/*
 * The lost-and-found box: everything in one jumbled pile. Look at the
 * items one at a time, from the first, until you find the one you want.
 * Return how many items you looked at. If it isn't in the box, you
 * looked at every item. An empty box takes 0 looks.
 *
 * looksInBox(["Red Umbrella", "Left Mitten", "Soccer Ball"], "Left Mitten") -> 2
 * looksInBox(["Red Umbrella", "Left Mitten", "Soccer Ball"], "Purple Scarf") -> 3
 */
export function looksInBox(box: string[], wanted: string): number {
  return 0;
}

/*
 * The labeled shelves: the same things, sorted onto shelves by kind
 * ("Bottles", "Books"...). Look only on the shelf you're told, one item
 * at a time from the first, and return how many items you looked at.
 * If the item isn't on that shelf, you looked at the whole shelf.
 * If there's no shelf with that name, there was nothing to look at: 0.
 *
 * looksOnShelf(shelves, "Bottles", "Blue Water Bottle") -> 2
 * looksOnShelf(shelves, "Toys", "Yo-yo") -> 0
 */
export function looksOnShelf(shelves: Record<string, string[]>, shelf: string, wanted: string): number {
  return 0;
}

/*
 * The cubbies: one item in each numbered cubby, numbered from 0.
 * Return what's in cubby number `number`, in one step: no looking
 * through the others. If there's no cubby with that number, return
 * "empty".
 *
 * itemInCubby(["Red Umbrella", "Left Mitten"], 1) -> "Left Mitten"
 * itemInCubby(["Red Umbrella", "Left Mitten"], 5) -> "empty"
 */
export function itemInCubby(cubbies: string[], number: number): string {
  return "";
}
