using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.Model.CRUD;

public class SeedData
{
    public static void PopulateDb(SouthwindContext db)
    {
        db.Database.EnsureCreated();

        var customers = new[]
        {
                new Customer { CustomerId = "ALICS", ContactName = "Alice Smith", City = "New York", Country = "USA", PostalCode = "10001" },
                new Customer { CustomerId = "BOBRO", ContactName = "Bob Ross", City = "London", Country = "UK", PostalCode = "SW1A 2AA" },
                new Customer { CustomerId = "CHARC", ContactName = "Charlie Chaplin", City = "Sydney", Country = "Australia", PostalCode = "2000" }
        };

        db.Customers.AddRange(customers);
        db.SaveChanges();

        
        var orders = new[]
        {
                new Order { OrderId = 1001, CustomerId = "ALICS", OrderDate = new DateTime(2023, 4, 24), ShippedDate = new DateTime(2023, 4, 25), ShipCountry = "USA" },
                new Order { OrderId = 1002, CustomerId = "BOBRO", OrderDate = new DateTime(2023, 4, 25), ShippedDate = new DateTime(2023, 4, 26), ShipCountry = "UK" },
                new Order { OrderId = 1003, CustomerId = "CHARC", OrderDate = new DateTime(2023, 4, 25), ShippedDate = new DateTime(2023, 4, 26), ShipCountry = "Australia" }
        };

        db.Orders.AddRange(orders);
        db.SaveChanges();

        var orderDetails = new[]
        {
            new OrderDetail { OrderDetailId = 1001, OrderId = 1001, UnitPrice = 5.00m, Quantity = 2, Discount = 0.10f },
            new OrderDetail { OrderDetailId = 1002, OrderId = 1002, UnitPrice = 25.00m, Quantity = 1, Discount = 0.00f },
            new OrderDetail { OrderDetailId = 1003, OrderId = 1003, UnitPrice = 3.00m, Quantity = 3, Discount = 0.20f }
        };
        
        db.OrderDetails.AddRange(orderDetails);
        db.SaveChanges();

        /* To populate database using SeedData call
         *
         *
         * using(var db = new SouthwindContext())
         * {
         *      SeedData.Populate(db);
         * }
         * 
         * in the main program
         * 
         */
    }

}
