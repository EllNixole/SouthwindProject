using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Read : DataAction
{
    public override void Execute(string customerID)
    {
        using (var db = new SouthwindContext())
        {
            switch (customerID.ToLower())
            {
                case "all":
                    foreach (var customerData in db.Customers) Console.WriteLine($"CustomerID: {customerData.CustomerId} Full Name: {customerData.ContactName} City: {customerData.City} Country: {customerData.Country} Post Code: {customerData.PostalCode}");
                    break;
                default:
                    var singleCustomerData = db.Customers.Find(customerID);
                    Console.WriteLine($"CustomerID: {singleCustomerData.CustomerId} Full Name: {singleCustomerData.ContactName} City: {singleCustomerData.City} Country: {singleCustomerData.Country} Post Code: {singleCustomerData.PostalCode}");
                    break;
            }

        }
    }
}
    

