import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.junit.jupiter.api.Test;

// The tests for your three methods. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
class FinderTest {
    private static final List<String> BOX = List.of("Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball");

    private static Map<String, List<String>> shelves() {
        Map<String, List<String>> shelves = new HashMap<>();
        shelves.put("Bottles", List.of("Green Water Bottle", "Blue Water Bottle"));
        shelves.put("Books", List.of("Math Textbook"));
        shelves.put("Clothing", List.of("Left Mitten"));
        shelves.put("Sports", List.of("Bike Helmet", "Soccer Ball"));
        shelves.put("Other", List.of("Red Umbrella", "Phone Charger"));
        return shelves;
    }

    @Test
    void looksInBoxFindsTheFirstItemInOneLook() {
        assertEquals(1, Finder.looksInBox(BOX, "Red Umbrella"), "Not yet: Red Umbrella is the first item, so it takes 1 look.");
    }

    @Test
    void looksInBoxCountsEveryItemUpToTheOneYouWant() {
        assertEquals(3, Finder.looksInBox(BOX, "Left Mitten"), "Not yet: Left Mitten is the third item, so it takes 3 looks.");
        assertEquals(7, Finder.looksInBox(BOX, "Blue Water Bottle"), "Not yet: Blue Water Bottle is the seventh item, so it takes 7 looks.");
    }

    @Test
    void looksInBoxLooksAtEverythingWhenTheItemIsMissing() {
        assertEquals(8, Finder.looksInBox(BOX, "Purple Scarf"), "Not yet: Purple Scarf isn't in the box, so you look at all 8 items.");
        assertEquals(0, Finder.looksInBox(List.of(), "Purple Scarf"), "Not yet: an empty box takes 0 looks.");
    }

    @Test
    void looksOnShelfLooksOnlyOnThatShelf() {
        assertEquals(2, Finder.looksOnShelf(shelves(), "Bottles", "Blue Water Bottle"), "Not yet: Blue Water Bottle is second on the Bottles shelf, so it takes 2 looks.");
        assertEquals(2, Finder.looksOnShelf(shelves(), "Sports", "Soccer Ball"), "Not yet: Soccer Ball is second on the Sports shelf, so it takes 2 looks.");
    }

    @Test
    void looksOnShelfLooksAtTheWholeShelfWhenTheItemIsMissing() {
        assertEquals(1, Finder.looksOnShelf(shelves(), "Books", "Science Textbook"), "Not yet: the Books shelf holds 1 item, so a missing book takes 1 look.");
        assertEquals(0, Finder.looksOnShelf(shelves(), "Toys", "Yo-yo"), "Not yet: there's no Toys shelf, so there's nothing to look at: 0 looks.");
    }

    @Test
    void itemInCubbyGivesWhatsInThatCubby() {
        assertEquals("Blue Water Bottle", Finder.itemInCubby(BOX, 6), "Not yet: cubby 6 holds Blue Water Bottle (cubbies are numbered from 0).");
        assertEquals("Red Umbrella", Finder.itemInCubby(BOX, 0), "Not yet: cubby 0 is the first cubby, and it holds Red Umbrella.");
    }

    @Test
    void itemInCubbySaysEmptyForANumberWithNoCubby() {
        assertEquals("empty", Finder.itemInCubby(BOX, 8), "Not yet: the cubbies are numbered 0 to 7, so there's no cubby 8: \"empty\".");
        assertEquals("empty", Finder.itemInCubby(BOX, -1), "Not yet: there's no cubby -1: \"empty\".");
    }
}
