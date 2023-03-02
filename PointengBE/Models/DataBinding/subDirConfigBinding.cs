namespace PointengBE.Models.DataBinding
{
    public class subDirConfigBinding
    {
        public Guid PlanId { get; set; }
        public DateTime Month { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? REGION { get; set; }
        public string? CITY { get; set; }
        public string? ZONE { get; set; }
        public string? AREA { get; set; }
        public string? SUBAREA { get; set; }
        public string? SUBDEALER { get; set; }
        public int SubConfigId { get; set; }
        public string? UserName { get; set; }
        public string? DateEntry { get; set; }
        public List<SubConfig>? SubConfigs { get; set; }
    }
}
