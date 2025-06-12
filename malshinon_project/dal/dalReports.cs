using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
namespace malshinon
{
    public class DalReports
    {
        MySql MYsql;

        public DalReports(MySql mySql)
        {
            MYsql = mySql;
        }


        public void insertReport(Pepole reporter, Pepole target, string text)
        {
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO intelreports (reporter_id,target_id,text)
                             VALUES(@reporter_id,@target_id,@text)", conn);
                cmd.Parameters.AddWithValue("@reporter_id", reporter.Id);
                cmd.Parameters.AddWithValue("@target_id", target.Id);
                cmd.Parameters.AddWithValue("@text", text);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            finally
            {
                MYsql.close();
            }
        }



        public List<Intelreports> CreateListOfReportsById(Pepole reporter)
        {
            List<Intelreports> reports = new List<Intelreports>();
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM intelreports WHERE reporter_id = {reporter.Id}", conn);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int reporterId = reader.GetInt32("reporter_id");
                    int targetId = reader.GetInt32("target_id");
                    string text = reader.GetString("text");
                    DateTime timestampext = reader.GetDateTime("timestamp");
                    Intelreports intelreports = new Intelreports(id,reporterId,targetId,text,timestampext);
                    reports.Add(intelreports);
                }
                return reports;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return reports;
            }
            finally
            {
                MYsql.close();
            }
        }

        public List<Intelreports> ListOfAllReportsAboutTarget(Pepole target)
        {
            List<Intelreports> reports = new List<Intelreports>();
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM intelreports WHERE target_id = {target.Id}", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int reporterId = reader.GetInt32("reporter_id");
                    int targetId = reader.GetInt32("target_id");
                    string text = reader.GetString("text");
                    DateTime timestampext = reader.GetDateTime("timestamp");
                    Intelreports intelreports = new Intelreports(id, reporterId, targetId, text, timestampext);
                    reports.Add(intelreports);
                }
                return reports;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return reports;
            }
            finally
            {
                MYsql.close();
            }
        }


    }
}

