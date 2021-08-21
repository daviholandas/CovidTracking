using BoxTI.Challenge.CovidTracking.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxTI.Challenge.CovidTracking.WebApi.Data.EntitiesMapping
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasMany(l => l.Reports)
                .WithOne(r => r.Location);
            
            builder.HasData(
                new Location("Brazil", "BR"),
                new Location("Japan", "JP"),
                new Location("Netherlands", "NL"),
                new Location("Nigeria", "NG"),
                new Location("Australia", "AU"),
                new Location("World", "W")
            );
        }
    }
}