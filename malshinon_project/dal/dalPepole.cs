using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
namespace malshinon
{
    public class DalPepole
    {
        MySql MYsql;

        public DalPepole(MySql mySql)
        {
            MYsql = mySql;
        }
      

        // בודקת אם יש אותו ברשימה ובמידה וכן מחזירה אותו
        public Pepole FindByFuulName(List<string> fullName)
        {
            Pepole pepole = null;
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pepole WHERE first_name = @firstname AND last_name = @lastname", conn);
                cmd.Parameters.AddWithValue("@firstname", fullName[0]);
                cmd.Parameters.AddWithValue("@lastname", fullName[1]);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string secretCode = reader.GetString("secret_code");
                    string type = reader.GetString("type");
                    int numReports = reader.GetInt32("num_reports");
                    int numMentions = reader.GetInt32("num_mentions");
                    pepole = new Pepole(id, firstName, secretCode, lastName, type,numReports,numMentions);
                }
                return pepole;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return pepole;
            }
            finally
            {
                MYsql.close();
            }
        }

        //bool מייצרת אדם חדש ומוסיפה לטבלה ומחזירה  
        public bool AddPersonToTable(List<string> fullName, string type)
        {
            bool x = false;
            Pepole pepole = null;
            Random rnd = new Random();
            string SecretCode = $" {fullName[0].ToString()}{rnd.Next(1234,5678)}";
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO pepole (first_name,last_name,secret_code,type)
                             VALUES(@first_name,@last_name,@secret_code,@type)", conn);
                cmd.Parameters.AddWithValue("@first_name", fullName[0]);
                cmd.Parameters.AddWithValue("@last_name", fullName[1]);
                cmd.Parameters.AddWithValue("@secret_code", SecretCode);
                cmd.Parameters.AddWithValue("@type", type);
                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return x;
            }
            finally
            {
                MYsql.close();
            }
        }

        //  יצירת אוביייקט מתוך הבסיס נתונים והחזרת אובייקט
        public Pepole CreatingLocalPerson(List<string> fullName)
        {
            Pepole pepole = null;
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pepole WHERE first_name = @firstname AND last_name = @lastname", conn);
                cmd.Parameters.AddWithValue("@firstname", fullName[0]);
                cmd.Parameters.AddWithValue("@lastname", fullName[1]);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string secretCode = reader.GetString("secret_code");
                    string type = reader.GetString("type");
                    int numReports = reader.GetInt32("num_reports");
                    int numMentions = reader.GetInt32("num_mentions");
                    pepole = new Pepole(id, firstName, secretCode, lastName, type,numReports,numMentions);
                }

                return pepole;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return pepole;
            }
            finally
            {
                MYsql.close();
            }
        }


        //הוספה למספר איזכורים על מטרה מסויימת
        public void addNumReports(Pepole pepole)
        {
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"UPDATE pepole SET num_reports = num_reports+1 WHERE id = {pepole.Id}", conn);
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

        //הוספה למספר דיווחים שהגיעו מאדם מסויים
        public void addNumMentions(Pepole pepole)
        {
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"UPDATE pepole SET num_mentions = num_mentions+1 WHERE id = {pepole.Id}", conn);
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


        // מחזירה את כל השמות הסודיים של סוכנים
        public List<string> ReturnAllOptionalAgentsSecretCode()
        {
            List<string> OptionalAgentsSecretCode = null;
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT secret_code FROM pepole WHERE type = 'potential_agent'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string SecretCode = reader.GetString("secret_code");
                    OptionalAgentsSecretCode.Add(SecretCode);
                }
                return OptionalAgentsSecretCode;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return OptionalAgentsSecretCode;

            }
            finally
            {
                MYsql.close();
            }
        }

        public List<Pepole> ReturnAllPepoleInList()
        {
            List<Pepole> AllPepole = new List<Pepole>();
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pepole;", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("first_name");
                    string lastName = reader.GetString("last_name");
                    string secretCode = reader.GetString("secret_code");
                    string type = reader.GetString("type");
                    int numReports = reader.GetInt32("num_reports");
                    int numMentions = reader.GetInt32("num_mentions");
                    Pepole pepole = new Pepole(id, firstName, secretCode, lastName, type, numReports, numMentions);
                    AllPepole.Add(pepole);
                }

                return AllPepole;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return AllPepole;
            }
            finally
            {
                MYsql.close();
            }
        }
    }
}

