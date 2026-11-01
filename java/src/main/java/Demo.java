import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

// Tries your methods on the lost-and-found. Run it with: java src/main/java/Demo.java
public class Demo {
    public static void main(String[] args) {
        List<String> box = List.of("Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball");
        Map<String, List<String>> shelves = new LinkedHashMap<>();
        shelves.put("Bottles", List.of("Green Water Bottle", "Blue Water Bottle"));
        shelves.put("Books", List.of("Math Textbook"));
        shelves.put("Clothing", List.of("Left Mitten"));
        shelves.put("Sports", List.of("Bike Helmet", "Soccer Ball"));
        shelves.put("Other", List.of("Red Umbrella", "Phone Charger"));
        List<String> cubbies = new ArrayList<>(box);

        System.out.println("Box: " + String.join(", ", box));
        System.out.println("Looks in the box for Blue Water Bottle: " + Finder.looksInBox(box, "Blue Water Bottle"));
        System.out.println("Looks on the Bottles shelf for Blue Water Bottle: " + Finder.looksOnShelf(shelves, "Bottles", "Blue Water Bottle"));
        System.out.println("Cubby 6 holds: " + Finder.itemInCubby(cubbies, 6));
    }
}
