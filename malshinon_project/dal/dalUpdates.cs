using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
namespace malshinon
{
    public class DalUpdates
    {
        MySql mySql;
        public DalUpdates(MySql mysql)
        {
            mySql = mysql;
        }



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

        public double AverageCalculation(double numReports,double sumreportsLengths)
        {
            return sumreportsLengths / numReports;
        }

        public bool averageReports(Pepole reporter)
        {
            double numReports = reporter.NumMentions;
            double sumreportsLengths = 0;
            if (numReports >= 10)
            {
                DalReports dalReports = new DalReports(mySql);
                List<Intelreports> reports = dalReports.CreateListOfReportsById(reporter);

                foreach (var report in reports)
                {
                    sumreportsLengths += report.Text.Length;
                }
                return (AverageCalculation(numReports, sumreportsLengths) >= 100);
            }
            else
            {
                return false;
            }
        }
        

        //הפיכת מודיע לסוכן לפי חישוב של ההודעות שסיפק
        public void updateTypeToReporterToAgent(Pepole reporter)
        {
            try
            {
                MySqlConnection conn = mySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"UPDATE pepole SET type = 'potential_agent' WHERE id = {reporter.Id}", conn);
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


        // זורקת ההתראה במקרה שיש יותר מ20 התראות על מטרה מסויימת
        public void DangerWarning(Pepole target)
        {
            if (target.NumReports >= 19)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Danger!!!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



    }
}
