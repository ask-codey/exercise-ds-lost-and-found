using LostAndFound;

namespace LostAndFound.Tests;

// The tests for your three methods. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.

[TestClass]
public class FinderTests
{
    private static readonly List<string> Box = new List<string> { "Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball" };

    private static Dictionary<string, List<string>> Shelves() => new Dictionary<string, List<string>>
    {
        ["Bottles"] = new List<string> { "Green Water Bottle", "Blue Water Bottle" },
        ["Books"] = new List<string> { "Math Textbook" },
        ["Clothing"] = new List<string> { "Left Mitten" },
        ["Sports"] = new List<string> { "Bike Helmet", "Soccer Ball" },
        ["Other"] = new List<string> { "Red Umbrella", "Phone Charger" }
    };

    [TestMethod]
    public void LooksInBoxFindsTheFirstItemInOneLook()
    {
        Assert.AreEqual(1, Finder.LooksInBox(Box, "Red Umbrella"), "Not yet: Red Umbrella is the first item, so it takes 1 look.");
    }

    [TestMethod]
    public void LooksInBoxCountsEveryItemUpToTheOneYouWant()
    {
        Assert.AreEqual(3, Finder.LooksInBox(Box, "Left Mitten"), "Not yet: Left Mitten is the third item, so it takes 3 looks.");
        Assert.AreEqual(7, Finder.LooksInBox(Box, "Blue Water Bottle"), "Not yet: Blue Water Bottle is the seventh item, so it takes 7 looks.");
    }

    [TestMethod]
    public void LooksInBoxLooksAtEverythingWhenTheItemIsMissing()
    {
        Assert.AreEqual(8, Finder.LooksInBox(Box, "Purple Scarf"), "Not yet: Purple Scarf isn't in the box, so you look at all 8 items.");
        Assert.AreEqual(0, Finder.LooksInBox(new List<string>(), "Purple Scarf"), "Not yet: an empty box takes 0 looks.");
    }

    [TestMethod]
    public void LooksOnShelfLooksOnlyOnThatShelf()
    {
        Assert.AreEqual(2, Finder.LooksOnShelf(Shelves(), "Bottles", "Blue Water Bottle"), "Not yet: Blue Water Bottle is second on the Bottles shelf, so it takes 2 looks.");
        Assert.AreEqual(2, Finder.LooksOnShelf(Shelves(), "Sports", "Soccer Ball"), "Not yet: Soccer Ball is second on the Sports shelf, so it takes 2 looks.");
    }

    [TestMethod]
    public void LooksOnShelfLooksAtTheWholeShelfWhenTheItemIsMissing()
    {
        Assert.AreEqual(1, Finder.LooksOnShelf(Shelves(), "Books", "Science Textbook"), "Not yet: the Books shelf holds 1 item, so a missing book takes 1 look.");
        Assert.AreEqual(0, Finder.LooksOnShelf(Shelves(), "Toys", "Yo-yo"), "Not yet: there's no Toys shelf, so there's nothing to look at: 0 looks.");
    }

    [TestMethod]
    public void ItemInCubbyGivesWhatsInThatCubby()
    {
        Assert.AreEqual("Blue Water Bottle", Finder.ItemInCubby(Box, 6), "Not yet: cubby 6 holds Blue Water Bottle (cubbies are numbered from 0).");
        Assert.AreEqual("Red Umbrella", Finder.ItemInCubby(Box, 0), "Not yet: cubby 0 is the first cubby, and it holds Red Umbrella.");
    }

    [TestMethod]
    public void ItemInCubbySaysEmptyForANumberWithNoCubby()
    {
        Assert.AreEqual("empty", Finder.ItemInCubby(Box, 8), "Not yet: the cubbies are numbered 0 to 7, so there's no cubby 8: \"empty\".");
        Assert.AreEqual("empty", Finder.ItemInCubby(Box, -1), "Not yet: there's no cubby -1: \"empty\".");
    }
}
