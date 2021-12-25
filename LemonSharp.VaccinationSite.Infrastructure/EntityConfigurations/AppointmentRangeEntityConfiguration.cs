using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonSharp.VaccinationSite.Infrastructure.EntityConfigurations;

public class AppointmentRangeEntityConfiguration: IEntityTypeConfiguration<AppointmentRange>
{
    public void Configure(EntityTypeBuilder<AppointmentRange> builder)
    {
        builder.ToTable("AppointmentRanges");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Date);

    }
}
