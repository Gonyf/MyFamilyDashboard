using System;

namespace MyFamilyDashboard.Data
{
    public class BeerDataModel
    {
        public float AlcPercent { get; set; }
        public string Name { get; set; }
        public string Country { get; }
        public Guid CountryId { get; set; }
    }
}
