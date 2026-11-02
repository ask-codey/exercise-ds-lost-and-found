// The lost-and-found desk. The comment above each method says what it
// should do, with examples. Change the code so the desk keeps up with
// the lunch line, and write each method's growth rate in its comment.
export class Desk {
  box = []; // every item, in the order it was handed in
  looks = 0; // how many items the desk has looked at, for every request so far

  /*
   * An item is handed in, with its kind ("Bottles", "Clothing"...). Its tag
   * number is how many items were handed in before it: 0, 1, 2...
   *
   * add("Red Umbrella", "Other") -> the first item, tag 0
   *
   * Growth rate: (write it here)
   */
  add(item, kind) {
    this.box.push(item);
  }

  /*
   * A student asks for an item by its name and its kind. Return true if
   * the desk has it, false if not. Add 1 to this.looks for every item
   * the desk looks at.
   *
   * find("Blue Water Bottle", "Bottles") -> true
   * find("Purple Scarf", "Clothing") -> false
   *
   * Growth rate: (write it here)
   */
  find(item, kind) {
    for (const thing of this.box) {
      this.looks++;
      if (thing === item) {
        return true;
      }
    }
    return false;
  }

  /*
   * A student brings the tag number from the desk's log. Return that item
   * in one step, without looking through the others. Tags start at 0. If
   * no item has that tag, return "empty".
   *
   * itemWithTag(0) -> "Red Umbrella"  (the first item handed in)
   * itemWithTag(8) -> "empty"  (when only 8 items have come in)
   *
   * Growth rate: (write it here)
   */
  itemWithTag(number) {
    return "empty";
  }
}
