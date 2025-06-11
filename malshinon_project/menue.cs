using System;
namespace malshinon
{
    public class Menue
    {
        static public MySql mysql = new MySql();
        static public DalPepole dalpepole = new DalPepole(mysql);
        static public DalReports dalreports = new DalReports(mysql);
        static public DalUpdates dalUpdates = new DalUpdates(mysql);

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

            List<string> reporterName = EnterFullName();
            Pepole reporter = dalpepole.FindByFuulName(reporterName); 
            if (reporter == null)
            {
                dalpepole.AddPersonToTable(reporterName, "reporter");
                reporter = dalpepole.CreatingLocalPerson(reporterName);
            }
            else
            {
                dalUpdates.updateTypeToReporter(reporter);
            }
            dalpepole.addNumReports(reporter);
            if (dalUpdates.averageReports(reporter))
            {
                dalUpdates.updateTypeToTarget(reporter);
            }
            Console.WriteLine("Enter information about the goal: ");
            List<string> targetName = EnterFullName();
            Pepole target = dalpepole.FindByFuulName(targetName);
            if (target == null)
            {
                dalpepole.AddPersonToTable(targetName, "target");
                target = dalpepole.CreatingLocalPerson(targetName);
            }
            else
            {
                dalUpdates.updateTypeToTarget(target);
            }
            dalpepole.addNumMentions(target);
            dalUpdates.DangerWarning(target);
            string report = EnterReport();
            dalreports.insertReport(reporter, target, report);

        }
    }
}

