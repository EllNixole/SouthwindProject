using System.Data.SqlClient;

namespace EF_ModelFirst;
public class Update : DataAction
{
    public override void Execute(string customerID, string column, string value)
    {
        using (var db = new SouthwindContext())
        {
            var selectedCustomer = db.Customers.Find(customerID);

            // actually update the data
            selectedCustomer.GetType().GetProperty(column).SetValue(selectedCustomer, value);
            db.SaveChanges();
        }
    }
}