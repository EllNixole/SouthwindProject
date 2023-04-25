using EF_ModelFirst.Migrations;
using Microsoft.Extensions.Primitives;
using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Add : DataAction
{
    public override void Execute(Customer customer)
    {
        using (var db = new SouthwindContext())
        {

            db.Customers.Add(customer);

            db.SaveChanges();

        }
    }
}