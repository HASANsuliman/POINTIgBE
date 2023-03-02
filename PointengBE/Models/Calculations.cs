namespace PointengBE.Models
{
    public class Calculations
    {
        public int Id { get; set; }
        public Guid PlanId { get; set; }
        public DateTime Plan { get; set; }

        public string?  UserName { get; set; }
        public string ? DateEntry { get; set; }

        public Calculations(Guid planId, DateTime plan, string? userName, string? dateEntry)
        {
          
            PlanId = planId;
            Plan = plan;
            UserName = userName;
            DateEntry = dateEntry;
        }
    }
}
