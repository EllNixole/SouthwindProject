using System.Data.SqlClient;

namespace EF_ModelFirst;

public static class Read
{
    public static void ExecuteQuery(int choice)
    {
        var trainees = new List<Trainee>();

        using (var db = new AcademyContext())
        {
            switch (choice)
            {
                case -1:
                    foreach (var trainee in db.Trainees) Console.WriteLine(trainee);
                    break;
                default:
                    Console.WriteLine(db.Trainees.Find(choice));
                    break;
            }

        }
    }
}
    

