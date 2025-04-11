using System;
using System.Runtime.CompilerServices;
public class MenuItem
{
    public string Description { get; set;}
    public double Price { get; set;}
    public string Category { get; set;} //can be Appetizer, Main Course, or Dessert
    public DateTime DateAdded { get; set;}

    public MenuItem(string description, double price, string category)
    {
        Description = description;
        Price = price;
        Category = category;
        DateAdded = DateTime.Now;
        
    }

    public void DisplayItem()
    {
        string newTag = (DateTime.Now - DateAdded).TotalDays <= 14 ? "~ NEW ITEM ~ " : ""; //will mark the item as new if it was added less than 14 days ago
        Console.WriteLine(newTag + "Description: " + Description);
        Console.WriteLine("Price: $" + Price);
        Console.WriteLine("Category: " + Category + "\n");
        Console.WriteLine($"Added on: {DateAdded}\n");
    }
}

public class Menu 
{
    private List<MenuItem> menuItems;
    public DateTime LastUpdated { get; set;}

    public Menu()
    {
        menuItems = new List<MenuItem>();
        LastUpdated = DateTime.Now;
    }

    public void AddItem(MenuItem item)
    {
        menuItems.Add(item);
        LastUpdated = DateTime.Now;
    }

    public void DisplayMenu()
    {
        foreach (var item in menuItems)
        {
            item.DisplayItem();
        }
        Console.WriteLine($"Last updated at: {LastUpdated}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu restaurantMenu = new Menu();

        MenuItem ramen = new MenuItem("A bowl of tonkotsu ramen with some pork, a boiled egg, mushrooms, and bok choy.", 14.99 ,"Main Course");
        MenuItem onigiri = new MenuItem("Rice balls with perfectly cooked rice, filled with delicious salmon. Includes 3 rice balls.", 6.99 ,"Appetizer");
        MenuItem mochi = new MenuItem("Soft mochi rice cakes filled with delicious red bean paste filling. Includes 3 rice cakes.", 5.99 ,"Dessert");

        restaurantMenu.AddItem(ramen);
        restaurantMenu.AddItem(onigiri);
        restaurantMenu.AddItem(mochi);

        restaurantMenu.DisplayMenu();

    }
}

