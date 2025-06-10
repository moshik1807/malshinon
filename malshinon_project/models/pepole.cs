using System;
namespace malshinon
{
    public class Pepole
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }

        public Pepole(int id, string firstName, string secretCode, string lestName, string type)
        {
            Id = id;
            FirstName = firstName;
            LestName = lestName;
            SecretCode = secretCode;
            Type = type;
        }

        public Pepole(string firstName, string secretCode, string lestName, string type)
        {
            FirstName = firstName;
            LestName = lestName;
            SecretCode = secretCode;
            Type = type;
        }



    }
}
