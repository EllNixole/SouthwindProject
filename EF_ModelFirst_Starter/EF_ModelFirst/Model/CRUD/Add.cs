using EF_ModelFirst.Migrations;
using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Create : DataAction
{
    public override void ExecuteQuery( string name, string city, string country, string postalCode)
    {
        using (var db = new SouthwindContext())
        {
            var newCustomer = new Customer() { ContactName = name, City = city, Country = country, PostalCode = postalCode };

            db.Customers.Create(newCustomer);

            db.SaveChanges();

        }
    }
}