using System;
using System.Xml.Linq;
namespace malshinon
{
    public class Menu
    {
        static public MySql mysql = new MySql();
        static public DalPepole dalpepole = new DalPepole(mysql);
        static public DalReports dalreports = new DalReports(mysql);
        static public DalUpdates dalUpdates = new DalUpdates(mysql);

        public void menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("To create an alert, press 1.\n" +
                    "To get all reports about target by fullname press 2\n" +
                    "To get all optiona lAgents secret name press 3. \n" +
                    "To Exis, press 5.");
                int coice = int.Parse(Console.ReadLine());
                switch (coice)
                {
                    case 1:
                        NewAlert();
                        break;
                    case 2:
                        PrintAllReportsByName();
                        break;
                    case 3:
                        PrintAllOptionalAgents();
                        break;
                    case 4:
                        PrintsAllDangerous();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }   
        }

        // מקבלת שם מלא מהמשתמש
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


        //מקבלת שם מלא של המודיע ואת פרטי המטרה ואת ההתראה ומוסיפה
        public void NewAlert()
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
            dalpepole.addNumMentions(reporter);
            if (dalUpdates.averageReports(reporter))
            {
                dalUpdates.updateTypeToTarget(reporter);
            }
            if (dalUpdates.averageReports(reporter))
            {
                dalUpdates.updateTypeToReporterToAgent(reporter);
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
            dalpepole.addNumReports(target);
            dalUpdates.DangerWarning(target);
            string report = EnterReport();
            dalreports.insertReport(reporter, target, report);

            Console.WriteLine($"reporter:{reporter.FirstName} {reporter.LestName}\n" +
                $"report the message:\n" +
                $"{report}\n" +
                $"On target:{target.FirstName} {target.LestName}");
        }



        // מחזירה את כל ההתראות על אדם מסויים
        public void PrintAllReportsByName()
        {
            List<string> fullName = EnterFullName();
            Pepole target = dalpepole.FindByFuulName(fullName);
            if (target != null)
            {
                List<Intelreports> reports = dalreports.ListOfAllReportsAboutTarget(target);
                foreach (var report in reports)
                {
                    Console.WriteLine(report.Text);
                }
            }
            else
            {
                Console.WriteLine("There is no such thing as a goal.");
            }
        }
        

        public void PrintAllOptionalAgents()
        {
            List<string> OptionalAgents = dalpepole.ReturnAllOptionalAgentsSecretCode();
            if (OptionalAgents == null)
            {
                Console.WriteLine("no optional agents");
            }
            else
            {
                foreach(string Agents in OptionalAgents)
                {
                    Console.WriteLine(Agents);
                }
            }
        }

        public void PrintsAllDangerous()
        {
            bool resulte = false;
            List<Pepole> allPepole = dalpepole.ReturnAllPepoleInList();
            foreach(var pepole in allPepole)
            {
                if(pepole.NumMentions > 10)
                {
                    Console.WriteLine($"{pepole.FirstName} {pepole.LestName} he is dangerous");
                    resulte = true;
                }   
            }
            if (!resulte)
            {
                Console.WriteLine("No danger found.");
            }
        }
    }
}

