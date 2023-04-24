using System.Data.SqlClient;

namespace AcademySqlClient;

public static class Update
{
    public static void ExecuteQuery(int traineeID, string column, string value)
    {
        using (var db = new AcademyContext())
        {
            var selectedTrainee = db.Trainees.Find(traineeID);

            // actually update the data
            selectedTrainee.GetType().GetProperty(column).SetValue(selectedTrainee, value);
            db.SaveChanges();
        }
    }
}