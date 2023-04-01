using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PointengBE.Models

{
    public class SubDirectConfigProm
    {
        public int Id { get; set; }
        [ForeignKey("Plan")]
        public Guid PlanId { get; set; }
        [ForeignKey("DirectConfig")]
        public Guid RangeId { get; set; }
        [Required]
        public DateTime Month { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RangeFrom { get; set; }
        [Required]
        public int RangeTo { get; set; }
        [Required]
        public int SubConfigId { get; set; }
        [Required]
        public int Points { get; set; }
        public int ExtraPoints { get; set; }
        public string? REGION { get; set; }
        public string? CITY { get; set; }
        public string? ZONE { get; set; }
        public string? AREA { get; set; }
        public string? SUBAREA { get; set; }
        public string? UserName { get; set; }
        public string? DateEntry { get; set; }
        public string? SUBDEALER { get; set; }
        public SubDirectConfigProm(Guid PlanId, Guid RangeId, DateTime Month, DateTime DateFrom,
            DateTime DateTo, int SubConfigId, int RangeFrom, int RangeTo, int Points, int ExtraPoints, string REGION, string CITY,
             string ZONE, string AREA, string SUBAREA, string SUBDEALER, string UserName
           )
        {
            this.PlanId = PlanId;
            this.RangeId = RangeId;
            this.Month = Month;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
            this.RangeFrom = RangeFrom;
            this.RangeTo = RangeTo;
            this.Points = Points;
            this.ExtraPoints = ExtraPoints;
            this.REGION = REGION;
            this.CITY = CITY;
            this.ZONE = ZONE;
            this.AREA = AREA;
            this.SUBDEALER = SUBDEALER;
            this.SUBAREA = SUBAREA;
            this.SubConfigId = SubConfigId;
            this.UserName = UserName;
        }
    }
}
