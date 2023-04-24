using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Delete : DataAction
{
    public override void ExecuteQuery(int customerID)
    {
        using (var db = new SouthwindContext())
        {
            var customerToDelete = db.Customers.Find(customerID);
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();

        }
    }
}