using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
namespace malshinon
{
    public class CalculationFunctions
    {
        MySql mySql;
        public CalculationFunctions(MySql mysql)
        {
            mySql = mysql;
        }
        //public bool checkIfTarget(Pepole pepole)
        //{

        //}
        //public bool checkIfReporter(Pepole pepole)
        //{

        //}
        public void updateTypeToReporter(Pepole reporter)
        {
            if (reporter.Type == "target")
            {
                try
                {
                    MySqlConnection conn = mySql.GetConnection();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE pepole SET type = 'both' WHERE id = {reporter.Id}", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
                finally
                {
                    mySql.close();
                }
            }
        }

        public void updateTypeToTarget(Pepole target)
        {
            if (target.Type == "reporter")
            {
                try
                {
                    MySqlConnection conn = mySql.GetConnection();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE pepole SET type = 'both' WHERE id = {target.Id}", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
                finally
                {
                    mySql.close();
                }
            }
        }




    }
}
