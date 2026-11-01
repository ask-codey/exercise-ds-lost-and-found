using LostAndFound;

// Tries your methods on the lost-and-found. Run it with: dotnet run --project LostAndFound
List<string> box = new List<string> { "Red Umbrella", "Math Textbook", "Left Mitten", "Green Water Bottle", "Bike Helmet", "Phone Charger", "Blue Water Bottle", "Soccer Ball" };
Dictionary<string, List<string>> shelves = new Dictionary<string, List<string>>
{
    ["Bottles"] = new List<string> { "Green Water Bottle", "Blue Water Bottle" },
    ["Books"] = new List<string> { "Math Textbook" },
    ["Clothing"] = new List<string> { "Left Mitten" },
    ["Sports"] = new List<string> { "Bike Helmet", "Soccer Ball" },
    ["Other"] = new List<string> { "Red Umbrella", "Phone Charger" }
};
List<string> cubbies = new List<string>(box);

Console.WriteLine("Box: " + string.Join(", ", box));
Console.WriteLine("Looks in the box for Blue Water Bottle: " + Finder.LooksInBox(box, "Blue Water Bottle"));
Console.WriteLine("Looks on the Bottles shelf for Blue Water Bottle: " + Finder.LooksOnShelf(shelves, "Bottles", "Blue Water Bottle"));
Console.WriteLine("Cubby 6 holds: " + Finder.ItemInCubby(cubbies, 6));
