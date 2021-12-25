using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationSite.Infrastructure.EntityConfigurations;

public class
    VaccinationSiteEntityConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.ToTable("VaccinationSites");

        builder.Ignore(b => b.DomainEvents);

        builder.HasKey(u => u.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasMany(b => b.AppointmentRanges)
            .WithOne()
            .HasForeignKey(b => b.SiteId);
        
        var appointmentRangesNavigation = builder.Metadata.FindNavigation(nameof(Site.AppointmentRanges));
        ArgumentNullException.ThrowIfNull(appointmentRangesNavigation);
        appointmentRangesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
