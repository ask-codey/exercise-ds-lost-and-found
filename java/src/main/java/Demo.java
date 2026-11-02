// Tries the desk on eight items. Run it with: java src/main/java/Demo.java
public class Demo {
    public static void main(String[] args) {
        String[][] items = {
            {"Red Umbrella", "Other"}, {"Math Textbook", "Books"}, {"Left Mitten", "Clothing"},
            {"Green Water Bottle", "Bottles"}, {"Bike Helmet", "Sports"}, {"Phone Charger", "Other"},
            {"Blue Water Bottle", "Bottles"}, {"Soccer Ball", "Sports"}
        };

        Desk desk = new Desk();
        for (String[] item : items) {
            desk.add(item[0], item[1]);
        }

        String[][] requests = {{"Blue Water Bottle", "Bottles"}, {"Purple Scarf", "Clothing"}};
        for (String[] request : requests) {
            int before = desk.looks();
            String answer = desk.find(request[0], request[1]) ? "yes" : "no";
            System.out.println(request[0] + " (" + request[1] + "): " + answer + ", looks: " + (desk.looks() - before));
        }
        System.out.println("Tag 6: " + desk.itemWithTag(6));
    }
}
