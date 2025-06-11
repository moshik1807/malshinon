using System;
namespace malshinon
{
    public class Intelreports
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public Intelreports(int id, int reporterId, int targetId, string text,DateTime timestamp)
        {
            Id = id;
            ReporterId = reporterId;
            TargetId = targetId;
            Text = text;
            Timestamp = timestamp;
        }
    }
}

