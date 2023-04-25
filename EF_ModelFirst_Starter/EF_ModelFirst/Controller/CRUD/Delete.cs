<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Data.SqlClient;
=======
﻿using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
>>>>>>> dev

namespace EF_ModelFirst;

public class Delete : DataAction
{
    public override void Execute(string customerID)
    {
        using (var db = new SouthwindContext())
        {
<<<<<<< HEAD
            List<Order> orderToDelete = new List<Order> { db.Orders.Find(customerID) };
            List<OrderDetail> orderDetailToDelete = new List<OrderDetail> { db.OrderDetails. };
            foreach (var orders in orderToDelete)
            {
                orderDetailToDelete = new List<OrderDetail> { };
                orderDetailToDelete.Add(db.OrderDetails.Find(orders.OrderId));
                foreach (var orderDetails in orderDetailToDelete)
                {
                    db.OrderDetails.Remove(db.OrderDetails.Find(orderDetails.OrderId));
                }                
                db.Orders.Remove(db.Orders.Find(orders.OrderId));                
            }

            var customerToDelete = db.Customers.Find(customerID);
            db.Customers.Remove(customerToDelete);

            db.SaveChanges();
=======
            var customerToDelete = db.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderDetails)
            .FirstOrDefault(c => c.CustomerId == customerID);
>>>>>>> dev

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