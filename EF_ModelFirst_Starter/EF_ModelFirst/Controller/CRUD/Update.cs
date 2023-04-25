using System.Data.SqlClient;

namespace EF_ModelFirst;
public class Update : IDataAction
{
    public void Execute()
    {
        (string customerID, string column, string value) = View.GetUpdateData();

        using (var db = new SouthwindContext())
        {
            var selectedCustomer = db.Customers.Find(customerID);

            // actually update the data
            selectedCustomer.GetType().GetProperty(column).SetValue(selectedCustomer, value);
            db.SaveChanges();
        }
    }
}