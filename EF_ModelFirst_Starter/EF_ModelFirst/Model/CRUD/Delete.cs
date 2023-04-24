using System.Data.SqlClient;

namespace AcademySqlClient;

public static class Delete
{
    public static void ExecuteQuery(int traineeID)
    {
        using (var db = new AcademyContext())
        {
            var query = $"DELETE FROM Trainees WHERE TraineeID = {traineeID}";

            var traineeToDelete = db.Trainees.Find(traineeID);
            db.Trainees.Remove(traineeToDelete);
            db.SaveChanges();

        }
    }
}