using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointengBE.Models
{
    public class DirectConfig
    {
        public Guid Id { get; set; }
        [ForeignKey("Plan")]
        [Required]
        public Guid PlanId { get; set; }
        [Required]
        public DateTime Month { get; set; }

        public int RangeFrom { get; set; }
        [Required]
        public int RangeTo { get; set; }
        [Required]
        public int Points { get; set; }
        public string? UserName { get; set; }
        public string? DateEntry { get; set; }
        public DateTime? DateDeleted { get; set; }
        public virtual Plan? Plan { get; set; }

        public DirectConfig(Guid PlanId, DateTime Month, int RangeFrom, int RangeTo, int Points, string UserName)

        {
            // this.Id = Id;
            this.PlanId = PlanId;
            this.Month = Month;
            this.RangeFrom = RangeFrom;
            this.RangeTo = RangeTo;
            this.Points = Points;
            this.UserName = UserName;


        }
    }
}
