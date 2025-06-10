namespace malshinon
{
    class program
    {
        static void Main()
        {
            MySql mysql = new MySql();
            DalPepole dalpepole = new DalPepole(mysql);
            List<string> fullname = new List<string> { "mochamad", "xxx" };
            //dalpepole.AddPerson(fullname, "reporter");
            Console.WriteLine(dalpepole.Check(fullname));
            Pepole x = dalpepole.creatNewPepole(fullname);
            dalpepole.addNumReports(x);
        }
    }
}