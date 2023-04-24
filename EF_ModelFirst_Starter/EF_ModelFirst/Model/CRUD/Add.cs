using System.Data.SqlClient;

namespace EF_ModelFirst;

public static class Add
{
    public static void ExecuteQuery( string name, string course, string location)
    {
        using (var db = new AcademyContext())
        {
            var newTrainee = new Trainee() { Name = name, Course = course, Location = location };

            db.Trainees.Add(newTrainee);

            db.SaveChanges();

        }
    }
}