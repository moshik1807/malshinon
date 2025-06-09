using MySql.Data.MySqlClient;
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
        public List<string> EnterFullName()
        {
            List<string> fullName = new List<string>();
            Console.WriteLine("enter first name");
            string first = Console.ReadLine();
            fullName.Add(first);
            Console.WriteLine("enter last name");
            string last = Console.ReadLine();
            fullName.Add(last);
            return fullName;
        }

        public bool Check(List<string> fullName)
        {
            bool result = false;
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pepole WHERE first_name = @firstname AND last_name = @lastname", conn);
                cmd.Parameters.AddWithValue("@firstname", fullName[0]);
                cmd.Parameters.AddWithValue("@ladtName", fullName[1]);
                var reader = cmd.ExecuteReader();
                result = reader.Read();
                return result;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return result;
            }
            finally
            {
                MYsql.close();
            }

        }
        public void AddPerson(List<string> fullName)
        {
            string secretCode = firstName[0].ToString() + (int)lastName[0];
            //Pepole newPepole = new Pepole(fullName[0], secretCode, fullName[1], "reporter")

            try
            {
                MySqlConnection conn = mySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO pepole (first_name,last_name,secret_code,type)
                             VALUES(@first_name,@last_name,@secret_code,@type)", conn);
                cmd.Parameters.AddWithValue("@first_name", fullName[0]);
                cmd.Parameters.AddWithValue("@last_name", fullName[1]);
                cmd.Parameters.AddWithValue("@secret_code", secretCode);
                cmd.Parameters.AddWithValue("@type", "reporter");
                int rowEfected = cmd.ExecuteNonQuery();
            }




        }
    }
}

