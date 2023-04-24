using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.Add(new Customer() { ContactName = "Philip Thomas", City = "IronBridge", CustomerId = "PHILT", PostalCode = "AB1 2CD" });
            db.Customers.Add(new Customer() { ContactName = "Danyal Saleh", City = "Reading", CustomerId = "DANYS", PostalCode = "AB1 2CB" });

            db.SaveChanges();
        }
    }
}
