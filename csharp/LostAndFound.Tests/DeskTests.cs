using LostAndFound;

namespace LostAndFound.Tests;

// The tests for the lost-and-found desk. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.

[TestClass]
public class DeskTests
{
    private static readonly string[][] Items =
    {
        new[] { "Red Umbrella", "Other" }, new[] { "Math Textbook", "Books" }, new[] { "Left Mitten", "Clothing" },
        new[] { "Green Water Bottle", "Bottles" }, new[] { "Bike Helmet", "Sports" }, new[] { "Phone Charger", "Other" },
        new[] { "Blue Water Bottle", "Bottles" }, new[] { "Soccer Ball", "Sports" }
    };

    // The lunch line: 800 items, 100 of each of 8 kinds, handed in all mixed up.
    private static readonly string[] Kinds = { "Bottles", "Books", "Clothing", "Sports", "Electronics", "Lunch Boxes", "Umbrellas", "Other" };
    private static readonly string[] Names = { "Water Bottle", "Textbook", "Hoodie", "Soccer Ball", "Phone Charger", "Lunch Box", "Umbrella", "Key Ring" };
    private const int Limit = 120;

    private static Desk SmallDesk()
    {
        Desk desk = new Desk();
        foreach (string[] item in Items)
        {
            desk.Add(item[0], item[1]);
        }
        return desk;
    }

    private static Desk BigDesk()
    {
        Desk desk = new Desk();
        for (int i = 0; i < 800; i++)
        {
            desk.Add(Names[i % 8] + " " + (i / 8 + 1), Kinds[i % 8]);
        }
        return desk;
    }

    private static (bool Found, int Looks) Ask(Desk desk, string item, string kind)
    {
        int before = desk.Looks;
        bool found = desk.Find(item, kind);
        return (found, desk.Looks - before);
    }

    [TestMethod]
    public void FindSaysWhetherTheDeskHasIt()
    {
        Desk desk = SmallDesk();
        Assert.IsTrue(desk.Find("Blue Water Bottle", "Bottles"), "Not yet: a Blue Water Bottle was handed in, so the desk has it.");
        Assert.IsTrue(desk.Find("Left Mitten", "Clothing"), "Not yet: a Left Mitten was handed in, so the desk has it.");
        Assert.IsFalse(desk.Find("Purple Scarf", "Clothing"), "Not yet: nobody handed in a Purple Scarf.");
        Assert.IsFalse(desk.Find("Yo-yo", "Toys"), "Not yet: nothing of the kind Toys was handed in.");
    }

    [TestMethod]
    public void FindCountsItsLooks()
    {
        (bool found, int looks) = Ask(SmallDesk(), "Blue Water Bottle", "Bottles");
        Assert.IsTrue(found && looks >= 1, "Not yet: finding the Blue Water Bottle means looking at it, so Looks should go up by at least 1.");
    }

    [TestMethod]
    public void ItemWithTagGivesTheItemsInTheOrderTheyCameIn()
    {
        Desk desk = SmallDesk();
        Assert.AreEqual("Red Umbrella", desk.ItemWithTag(0), "Not yet: tag 0 is the first item handed in, the Red Umbrella.");
        Assert.AreEqual("Blue Water Bottle", desk.ItemWithTag(6), "Not yet: tag 6 is the seventh item handed in, the Blue Water Bottle.");
    }

    [TestMethod]
    public void ItemWithTagSaysEmptyForATagNobodyHas()
    {
        Desk desk = SmallDesk();
        Assert.AreEqual("empty", desk.ItemWithTag(8), "Not yet: 8 items came in, tagged 0 to 7, so tag 8 is \"empty\".");
        Assert.AreEqual("empty", desk.ItemWithTag(-1), "Not yet: there's no tag -1, so it's \"empty\".");
    }

    [TestMethod]
    public void EveryStudentInTheLunchLineGetsAnAnswerIn120LooksOrFewer()
    {
        Desk desk = BigDesk();
        for (int i = 0; i < 800; i++)
        {
            string item = Names[i % 8] + " " + (i / 8 + 1);
            (bool found, int looks) = Ask(desk, item, Kinds[i % 8]);
            Assert.IsTrue(found, "Not yet: " + item + " was handed in, so the desk has it.");
            Assert.IsTrue(looks <= Limit, "Not yet: finding " + item + " took " + looks + " looks. The lunch line needs " + Limit + " or fewer, even with 800 items.");
        }
    }

    [TestMethod]
    public void AMissingItemIsAnsweredIn120LooksOrFewer()
    {
        Desk desk = BigDesk();
        foreach (string kind in Kinds)
        {
            (bool found, int looks) = Ask(desk, "Purple Scarf", kind);
            Assert.IsFalse(found, "Not yet: nobody handed in a Purple Scarf.");
            Assert.IsTrue(looks <= Limit, "Not yet: saying no to a Purple Scarf (" + kind + ") took " + looks + " looks. The lunch line needs " + Limit + " or fewer.");
        }
    }

    [TestMethod]
    public void TagsStillWorkWith800Items()
    {
        Desk desk = BigDesk();
        Assert.AreEqual("Water Bottle 1", desk.ItemWithTag(0), "Not yet: tag 0 is the first item handed in, Water Bottle 1.");
        Assert.AreEqual("Key Ring 100", desk.ItemWithTag(799), "Not yet: tag 799 is the last item handed in, Key Ring 100.");
        Assert.AreEqual("empty", desk.ItemWithTag(800), "Not yet: 800 items came in, tagged 0 to 799, so tag 800 is \"empty\".");
    }
}
