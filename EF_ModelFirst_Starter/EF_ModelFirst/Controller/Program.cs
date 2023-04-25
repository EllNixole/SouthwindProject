using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst;

class Program
{
    static void Main(string[] args)
    {
        /*using (var db = new SouthwindContext())
        {
            db.Customers.Add(new Customer() { ContactName = "Philip Thomas", City = "IronBridge", CustomerId = "PHILT", PostalCode = "AB1 2CD" });
            db.Customers.Add(new Customer() { ContactName = "Danyal Saleh", City = "Reading", CustomerId = "DANYS", PostalCode = "AB1 2CB" });

            db.SaveChanges();
        }*/

        Controller();
    }

    public static void Controller()
    {
        string choice = View.WelcomeMessage();

        bool valid = Int32.TryParse(choice, out int choiceNum);
        while (!valid || choiceNum < 1 || choiceNum > 4)
        {
            Console.WriteLine("Input valid choice: ");
            valid = Int32.TryParse(Console.ReadLine(), out choiceNum);
        }

        var crud = ActionFactory.GetAction(choiceNum);
        crud.Execute();
    }
}
