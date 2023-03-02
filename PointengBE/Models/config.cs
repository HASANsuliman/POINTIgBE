using System.ComponentModel.DataAnnotations;

namespace PointengBE.Models
{
    public class config
    {
        public int RangeFrom { get; set; }
        [Required]
        public int RangeTo { get; set; }
        [Required]
        public int Points { get; set; }
    }
}
