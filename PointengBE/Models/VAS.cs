﻿namespace PointengBE.Models
{
    public class VAS
    {
        public int Id { get; set; }
        public DateTime DAY { get; set; }
        public string? MONTH { get; set; }
        public string? EQUIPID { get; set; }
        public string? DESCRIPTION { get; set; }

        public string? SD_CODE { get; set; }
        public string? SD_NAME { get; set; }

        public string? SHOP_NAME { get; set; }
        public string? REGION { get; set; }
        public string? CITY { get; set; }
        public string? ZONE { get; set; }
        public string? AREA { get; set; }
        public string? SUBAREA { get; set; }
        public string? SUPERVISOR { get; set; }
        public string? RETAIL { get; set; }
        public string? SUBNO { get; set; }
        public string? CONTRANO { get; set; }
        public int? Point { get; set; }
        public int? Extrapoint { get; set; }

        public int? ToalPoint { get; set; }

    }
}
