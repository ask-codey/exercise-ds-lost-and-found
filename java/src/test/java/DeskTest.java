import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.Test;

// The tests for the lost-and-found desk. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
class DeskTest {
    private static final String[][] ITEMS = {
        {"Red Umbrella", "Other"}, {"Math Textbook", "Books"}, {"Left Mitten", "Clothing"},
        {"Green Water Bottle", "Bottles"}, {"Bike Helmet", "Sports"}, {"Phone Charger", "Other"},
        {"Blue Water Bottle", "Bottles"}, {"Soccer Ball", "Sports"}
    };

    // The lunch line: 800 items, 100 of each of 8 kinds, handed in all mixed up.
    private static final String[] KINDS = {"Bottles", "Books", "Clothing", "Sports", "Electronics", "Lunch Boxes", "Umbrellas", "Other"};
    private static final String[] NAMES = {"Water Bottle", "Textbook", "Hoodie", "Soccer Ball", "Phone Charger", "Lunch Box", "Umbrella", "Key Ring"};
    private static final int LIMIT = 120;

    private static Desk smallDesk() {
        Desk desk = new Desk();
        for (String[] item : ITEMS) {
            desk.add(item[0], item[1]);
        }
        return desk;
    }

    private static Desk bigDesk() {
        Desk desk = new Desk();
        for (int i = 0; i < 800; i++) {
            desk.add(NAMES[i % 8] + " " + (i / 8 + 1), KINDS[i % 8]);
        }
        return desk;
    }

    @Test
    void findSaysWhetherTheDeskHasIt() {
        Desk desk = smallDesk();
        assertTrue(desk.find("Blue Water Bottle", "Bottles"), "Not yet: a Blue Water Bottle was handed in, so the desk has it.");
        assertTrue(desk.find("Left Mitten", "Clothing"), "Not yet: a Left Mitten was handed in, so the desk has it.");
        assertFalse(desk.find("Purple Scarf", "Clothing"), "Not yet: nobody handed in a Purple Scarf.");
        assertFalse(desk.find("Yo-yo", "Toys"), "Not yet: nothing of the kind Toys was handed in.");
    }

    @Test
    void findCountsItsLooks() {
        Desk desk = smallDesk();
        boolean found = desk.find("Blue Water Bottle", "Bottles");
        assertTrue(found && desk.looks() >= 1, "Not yet: finding the Blue Water Bottle means looking at it, so looks should go up by at least 1.");
    }

    @Test
    void itemWithTagGivesTheItemsInTheOrderTheyCameIn() {
        Desk desk = smallDesk();
        assertEquals("Red Umbrella", desk.itemWithTag(0), "Not yet: tag 0 is the first item handed in, the Red Umbrella.");
        assertEquals("Blue Water Bottle", desk.itemWithTag(6), "Not yet: tag 6 is the seventh item handed in, the Blue Water Bottle.");
    }

    @Test
    void itemWithTagSaysEmptyForATagNobodyHas() {
        Desk desk = smallDesk();
        assertEquals("empty", desk.itemWithTag(8), "Not yet: 8 items came in, tagged 0 to 7, so tag 8 is \"empty\".");
        assertEquals("empty", desk.itemWithTag(-1), "Not yet: there's no tag -1, so it's \"empty\".");
    }

    @Test
    void everyStudentInTheLunchLineGetsAnAnswerIn120LooksOrFewer() {
        Desk desk = bigDesk();
        for (int i = 0; i < 800; i++) {
            String item = NAMES[i % 8] + " " + (i / 8 + 1);
            int before = desk.looks();
            boolean found = desk.find(item, KINDS[i % 8]);
            int looks = desk.looks() - before;
            assertTrue(found, "Not yet: " + item + " was handed in, so the desk has it.");
            assertTrue(looks <= LIMIT, "Not yet: finding " + item + " took " + looks + " looks. The lunch line needs " + LIMIT + " or fewer, even with 800 items.");
        }
    }

    @Test
    void aMissingItemIsAnsweredIn120LooksOrFewer() {
        Desk desk = bigDesk();
        for (String kind : KINDS) {
            int before = desk.looks();
            boolean found = desk.find("Purple Scarf", kind);
            int looks = desk.looks() - before;
            assertFalse(found, "Not yet: nobody handed in a Purple Scarf.");
            assertTrue(looks <= LIMIT, "Not yet: saying no to a Purple Scarf (" + kind + ") took " + looks + " looks. The lunch line needs " + LIMIT + " or fewer.");
        }
    }

    @Test
    void tagsStillWorkWith800Items() {
        Desk desk = bigDesk();
        assertEquals("Water Bottle 1", desk.itemWithTag(0), "Not yet: tag 0 is the first item handed in, Water Bottle 1.");
        assertEquals("Key Ring 100", desk.itemWithTag(799), "Not yet: tag 799 is the last item handed in, Key Ring 100.");
        assertEquals("empty", desk.itemWithTag(800), "Not yet: 800 items came in, tagged 0 to 799, so tag 800 is \"empty\".");
    }
}
