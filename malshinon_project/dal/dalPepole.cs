using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
namespace malshinon
{
    public class DalPepole
    {
        MySql MYsql;

        public DalPepole(MySql mySql)
        {
            MYsql = mySql;
        }
      

        //בודקת אם יש אותו ברשימה
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
                    pepole = new Pepole(id, firstName, secretCode, lastName, type);
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

        // מייצרת אדם חדש ומוסיפה לטבלה ומחזירה אובייקט 
        public bool AddPersonToTable(List<string> fullName, string type)
        {
            bool x = false;
            Pepole pepole = null;
            string SecretCode = fullName[0].ToString() + fullName[1].ToString();
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
                    pepole = new Pepole(id, firstName, secretCode, lastName, type);
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


        //הוספה למספר דיווחים שהגיעו מאדם מסויים
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

        //הוספה למספר איזכורים על מטרה מסויימת
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
        
      
        

    }
}

