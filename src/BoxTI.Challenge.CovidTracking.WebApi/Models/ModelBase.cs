using System;

namespace BoxTI.Challenge.CovidTracking.WebApi.Models
{
    public class ModelBase
    {
        public ModelBase()
            => Id = Guid.NewGuid();
        public Guid Id { get; private set; }
    }
}