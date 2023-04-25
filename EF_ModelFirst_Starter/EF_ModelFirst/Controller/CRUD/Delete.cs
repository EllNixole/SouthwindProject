using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;

namespace EF_ModelFirst;

public class Delete : DataAction
{
    public override void Execute(string customerID)
    {
        using (var db = new SouthwindContext())
        {
            var customerToDelete = db.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderDetails)
            .FirstOrDefault(c => c.CustomerId == customerID);

            if (customerToDelete != null)
            {
                foreach (var order in customerToDelete.Orders.ToList())
                {
                    foreach (var orderDetail in order.OrderDetails.ToList())
                    {
                        db.OrderDetails.Remove(orderDetail);
                    }

                    db.Orders.Remove(order);
                }

                db.Customers.Remove(customerToDelete);

                db.SaveChanges();

            }
        }
    }
}