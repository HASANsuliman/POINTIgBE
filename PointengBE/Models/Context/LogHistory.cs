namespace PointengBE.Models.Context
{
    public class LogHistory
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime Month { get; set; }
        public string? UserName { get; set; }
        public DateTime? DateDeleted { get; set; }
        public LogHistory( string type, DateTime month, string? userName, DateTime? dateDeleted)
        {
            Month = month;
            UserName = userName;
            DateDeleted = dateDeleted;
            Type = type;

        }

    }
}
