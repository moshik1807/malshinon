using MySql.Data.MySqlClient;
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
        public void EnterFullName()
        {
            Console.WriteLine("enter first name");
            string first = Console.ReadLine();
            Console.WriteLine("enter last name");
            string last = Console.ReadLine();
            Check(first, last);
        }

        public void Check(string firstName,string lastName)
        {
            try
            {
                MySqlConnection conn = MYsql.GetConnection();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pepole WHERE first_name = '{firstName}' AND last_name = '{lastName}'", conn)
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                }
                else
                {
                    AddPerson(firstName, lastName);
                }
                MYsql.close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
        }
        public void AddPerson(string firstName,string lastName)
        {
            string secretCode = firstName[0].ToString + int(lastName[0]);
            Pepole newPepole = new Pepole(firstName,secretCode,lastName, "reporter")

                
        }
    }
}

