using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EF_ModelFirst;

public class Read : DataAction
{
    public override void ExecuteQuery(int choice)
    {
        using (var db = new SouthwindContext())
        {
            switch (choice)
            {
                case -1:
                    foreach (var customer in db.Customers) Console.WriteLine(customer);
                    break;
                default:
                    Console.WriteLine(db.Customers.Find(choice));
                    break;
            }

        }
    }
}
    

