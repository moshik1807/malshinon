﻿using System;
namespace malshinon
{
    public class Pepole
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }

        public Pepole(int id, string firstName, string secretCode, string lestName, string type,int numReports,int numMentions)
        {
            Id = id;
            FirstName = firstName;
            LestName = lestName;
            SecretCode = secretCode;
            Type = type;
            NumReports = numReports;
            NumMentions = numMentions;
        }
    }
}
