namespace PointengBE.Models.DataBinding
{
    public class DirConfigBinding
    {
        public Guid PlanId { get; set; }
        public DateTime Month { get; set; }
        public string? UserName { get; set; }
        public string? DateEntry { get; set; }
        public List<config>? configs { get; set; }
    }
}
