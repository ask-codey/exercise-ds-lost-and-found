using LostAndFound;

// Tries the desk on eight items. Run it with: dotnet run --project LostAndFound
string[][] items =
{
    new[] { "Red Umbrella", "Other" }, new[] { "Math Textbook", "Books" }, new[] { "Left Mitten", "Clothing" },
    new[] { "Green Water Bottle", "Bottles" }, new[] { "Bike Helmet", "Sports" }, new[] { "Phone Charger", "Other" },
    new[] { "Blue Water Bottle", "Bottles" }, new[] { "Soccer Ball", "Sports" }
};

Desk desk = new Desk();
foreach (string[] item in items)
{
    desk.Add(item[0], item[1]);
}

foreach (string[] request in new[] { new[] { "Blue Water Bottle", "Bottles" }, new[] { "Purple Scarf", "Clothing" } })
{
    int before = desk.Looks;
    string answer = desk.Find(request[0], request[1]) ? "yes" : "no";
    Console.WriteLine(request[0] + " (" + request[1] + "): " + answer + ", looks: " + (desk.Looks - before));
}
Console.WriteLine("Tag 6: " + desk.ItemWithTag(6));
