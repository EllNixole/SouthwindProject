using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Delete : DataAction
{
    public void Execute(string customerID)
    {
        using (var db = new SouthwindContext())
        {
            var customerToDelete = db.Customers.Find(customerID);
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();

        }
    }
}