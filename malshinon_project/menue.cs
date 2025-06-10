using System;
namespace malshinon
{
    public class Menue
    {
        static public MySql mysql = new MySql();
        static public DalPepole dalpepole = new DalPepole(mysql);
        static public DalReports dalreports = new DalReports(mysql);

        //להעביר למיין
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
        
        //מקבלת טקסט ומחזירה
        public string EnterReport()
        {
            Console.WriteLine("enter your report");
            string text = Console.ReadLine();
            return text;
        }



        public void InsertingAlert()
        {

            List<string> fuulName = EnterFullName();
            Pepole reporter = dalpepole.FindByFuulName(fuulName); 
            if (reporter == null)
            {
                dalpepole.AddPerson(fuulName, "reporter");
                reporter = dalpepole.CreatingLocalPerson(fuulName);
            }
            


        }
    }
}

