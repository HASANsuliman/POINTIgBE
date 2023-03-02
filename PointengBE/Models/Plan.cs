using System.ComponentModel.DataAnnotations;

namespace PointengBE.Models
{
    public class Plan
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Month { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Required]
        public int PointPrice { get; set; }
        [Required]
        public int MinValue { get; set; }
        public string? UserName { get; set; }
        public string? UserUpdate { get; set; }
        public string? DateEntry { get; set; }
        public string? DateUpdated { get; set; }



        public virtual ICollection<DirectConfig>? DirectConfigs { get; set; }
        public Plan( DateTime month, DateTime dateFrom, DateTime dateTo, int pointPrice, int minValue)
        {
            Month = month;
            DateFrom = dateFrom;
            DateTo = dateTo;
            PointPrice = pointPrice;
            MinValue = minValue;
        }
    }
}
