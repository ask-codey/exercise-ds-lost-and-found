namespace LostAndFound;

// The lost-and-found desk. The comment above each method says what it
// should do, with examples. Change the code so the desk keeps up with
// the lunch line, and write each method's growth rate in its comment.
public class Desk
{
    private readonly List<string> box = new List<string>(); // every item, in the order it was handed in

    // How many items the desk has looked at, for every request so far.
    public int Looks { get; private set; }

    /*
     * An item is handed in, with its kind ("Bottles", "Clothing"...). Its tag
     * number is how many items were handed in before it: 0, 1, 2...
     *
     * Add("Red Umbrella", "Other") -> the first item, tag 0
     *
     * Growth rate: (write it here)
     */
    public void Add(string item, string kind)
    {
        box.Add(item);
    }

    /*
     * A student asks for an item by its name and its kind. Return true if
     * the desk has it, false if not. Add 1 to Looks for every item the
     * desk looks at.
     *
     * Find("Blue Water Bottle", "Bottles") -> true
     * Find("Purple Scarf", "Clothing") -> false
     *
     * Growth rate: (write it here)
     */
    public bool Find(string item, string kind)
    {
        foreach (string thing in box)
        {
            Looks++;
            if (thing == item)
            {
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
     * ItemWithTag(0) -> "Red Umbrella"  (the first item handed in)
     * ItemWithTag(8) -> "empty"  (when only 8 items have come in)
     *
     * Growth rate: (write it here)
     */
    public string ItemWithTag(int number)
    {
        return "empty";
    }
}
