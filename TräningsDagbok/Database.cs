using System.Data.SqlClient;
using System.Data;
using TräningsDagbok.Models;

namespace TräningsDagbok
{
    public class Database
    {
        public List<Exersice> GetExersices ()
        {
            List<Exersice> exerciseList = new List<Exersice>();
            SqlCommand cmd = GetSqlCommand();
            cmd.CommandText = "SELECT * FROM TRAINING_TABLE";

            var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                var exercise = new Exersice()
                {
                    id = int.Parse(reader["id"].ToString()),
                    exersice = reader["Exersice"].ToString(),
                    weight = reader["Weight"].ToString(),
                    date = reader["Date"].ToString()
                };
                exerciseList.Add(exercise);
            }
            return exerciseList;
        }

        public Exersice GetExerciseById(int id)
        {
            SqlCommand cmd = GetSqlCommand();
            cmd.CommandText = "SELECT * FROM Training_Table WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            var reader = cmd.ExecuteReader();


            while(reader.Read())
            {
                var exercise = new Exersice()
                {
                    id = int.Parse(reader["id"].ToString()),
                    exersice = reader["Exersice"].ToString(),
                    weight = reader["Weight"].ToString(),
                    date = reader["Date"].ToString()
                };
                return exercise;
            }
            return null;
        }

        public void DeleteExercise(int id)
        {
            SqlCommand cmd = GetSqlCommand();
            cmd.CommandText = "DELETE FROM Training_Table WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void AddExercise(Exersice exercise)
        {
            SqlCommand cmd = GetSqlCommand();
            cmd.CommandText = "INSERT INTO Training_Table (Exersice, Weight, Date) VALUES (@exersice, @weight, @date)";
            cmd.Parameters.AddWithValue("exersice", exercise.exersice);
            cmd.Parameters.AddWithValue("weight", exercise.weight);
            cmd.Parameters.AddWithValue("date", exercise.date);

            cmd.ExecuteNonQuery();
        } 

        public SqlCommand GetSqlCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=TrainingDB;Integrated Security=True";
            
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            return cmd;
        }
    }
}
