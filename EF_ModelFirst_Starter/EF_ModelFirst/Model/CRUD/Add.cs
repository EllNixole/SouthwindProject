using EF_ModelFirst.Migrations;
using Microsoft.Extensions.Primitives;
using System.Data.SqlClient;

namespace EF_ModelFirst;

<<<<<<< HEAD
public class Add : DataAction
=======
public class Add : IDataAction
>>>>>>> ee7f768dfda4bea42930a6579bbb0e3ce885d113
{
    public void Execute()
    {
        (string customerId, string name, string city, string country, string postalCode) = View.GetAddData();

        using (var db = new SouthwindContext())
        {
            var newCustomer = new Customer() { CustomerId = customerId, ContactName = name, City = city, Country = country, 
                PostalCode = postalCode };

            db.Customers.Add(newCustomer);

            db.SaveChanges();

        }
    }
}