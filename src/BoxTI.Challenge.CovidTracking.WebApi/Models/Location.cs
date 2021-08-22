using System.Collections.Generic;

namespace BoxTI.Challenge.CovidTracking.WebApi.Models
{
    public class Location : ModelBase
    {
        public Location(string name, string abbreviation)
            => (Name, Abbreviation, ActiveStatus) = (name, abbreviation, ActiveStatus.Actived);
        
        private Location(){}
        
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public ActiveStatus ActiveStatus { get; private set; }
        
        //EF relation
        public ICollection<Report> Reports { get; private set; }

        public void ChangeActiveStatus(ActiveStatus activeStatus)
            => ActiveStatus = activeStatus;
    }
}