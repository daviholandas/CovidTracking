using System;
using BoxTI.Challenge.CovidTracking.WebApi.Models;

namespace BoxTI.Challenge.CovidTracking.WebApi
{
    public struct ReportDto
    {
        public DateTime RegisterDate { get; set; }
        public double ActiveCases { get; set; }
        public double NewCases { get; set; }
        public double NewDeaths { get; set; }
        public double TotalCases { get; set; }
        public double TotalDeaths { get; set; }
        public double TotalRecovered { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Location { get; set; }
    }
}