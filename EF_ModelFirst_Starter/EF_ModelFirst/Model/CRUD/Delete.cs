using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Delete : IDataAction
{
    public void Execute()
    {
        string customerID = View.GetIDData();

        using (var db = new SouthwindContext())
        {
            var customerToDelete = db.Customers.Find(customerID);
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();

        }
    }
}