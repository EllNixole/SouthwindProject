using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst;

class Program
{
    static void Main(string[] args)
    {
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

        switch (crud)
        {
            case Add:
                crud.Execute(View.GetCustomerData());
                break;
            case Read:
                crud.Execute(View.GetIDData());
                break;
            case Update:
                crud.Execute(View.GetUpdateData().customerID, View.GetUpdateData().column, View.GetUpdateData().value);
                break;
            case Delete:
                crud.Execute(View.GetIDData());
                break;
        }
    }
}
