using System;

namespace EF_ModelFirst;

public static class View
{
    public static string WelcomeMessage()
    {
        Console.WriteLine("===== Welcome to the Southwind CRUD Project =====");
        Console.WriteLine("1: Add\n2: Read\n3: Update\n4: Delete");
        Console.Write("Your choice: ");
        return Console.ReadLine();
    }

    public static Customer GetCustomerData()
    {
        Console.Write("\nInput CustomerID: ");
        string customerID = Console.ReadLine();
        Console.Write("\nInput Name: ");
        string name = Console.ReadLine();
        Console.Write("\nInput City: ");
        string city = Console.ReadLine();
        Console.Write("\nInput Country: ");
        string country = Console.ReadLine();
        Console.Write("\nInput Post Code: ");
        string postalCode = Console.ReadLine();

        return new Customer() { CustomerId = customerID, ContactName = name, City = city, Country = country, PostalCode = postalCode};
    }
    public static string GetIDData()
    {
        Console.Write("\nInput CustomerID (type \"all\" to view all data: ");
        string customerID = Console.ReadLine();

        return customerID;
    }

    public static (string customerID, string column, string value) GetUpdateData()
    {
        Console.Write("\nInput CustomerID: ");
        string customerID = Console.ReadLine();
        Console.Write("\nInput Column: ");
        string column = Console.ReadLine();
        Console.Write("\nInput Value: ");
        string value = Console.ReadLine();

        return (customerID, column, value);
    }
}
