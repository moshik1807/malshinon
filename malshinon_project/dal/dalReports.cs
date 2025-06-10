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
                if (reporter == null)
                {
                    Console.WriteLine("a");
                }
                if (target == null)
                {
                    Console.WriteLine("b");
                }
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
    }
}

