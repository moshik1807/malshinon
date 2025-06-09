using System;
namespace malshinon
{
    public class Intelreports
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Text { get; set; }
        public Intelreports(int id,string text, int reporterId, int targetId, DateTime timestamp, string text)
        {
            Id = id;
            ReporterId = reporterId;
            TargetId = targetId;
            Timestamp = timestamp;
            Text = text;
        }
        public Intelreports(string text)
        {
            Text = text;
        }
    }
}

