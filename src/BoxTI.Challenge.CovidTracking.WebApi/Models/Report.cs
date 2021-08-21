using System;

namespace BoxTI.Challenge.CovidTracking.WebApi.Models
{
    public class Report : ModelBase
    {
        public Report(DateTime registerDate, string activeCases, string newCases, string newDeaths, double totalCases, 
            double totalDeaths, double totalRecovered, DateTime lastUpdate, Guid locationId)
        {
            RegisterDate = registerDate;
            ActiveCases = activeCases;
            NewCases = newCases;
            NewDeaths = newDeaths;
            TotalCases = totalCases;
            TotalDeaths = totalDeaths;
            TotalRecovered = totalRecovered;
            LastUpdate = lastUpdate;
            LocationId = locationId;
        }
        
        private Report(){}
        
        public DateTime RegisterDate { get; private set; }
        public string ActiveCases { get; private set; }
        public string NewCases { get; private set; }
        public string NewDeaths { get; private set; }
        public double TotalCases { get; private set; }
        public double TotalDeaths { get; private set; }
        public double TotalRecovered { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public Location Location { get; private set; }
        
        //EF relation
        public Guid LocationId { get; private set; }
    } 
}
