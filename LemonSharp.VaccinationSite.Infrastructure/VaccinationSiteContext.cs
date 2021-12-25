using LemonSharp.VaccinationSite.Domain.SeedWork;
using LemonSharp.VaccinationSite.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LemonSharp.VaccinationSite.Infrastructure;

public class VaccinationSiteContext : DbContext, IUnitOfWork
{
    public DbSet<Domain.AggregatesModel.VaccinationSiteAggregate.Site> Sites { get; set; } = null!;
    
    public VaccinationSiteContext(DbContextOptions<VaccinationSiteContext> options) : base(options)
    {
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await Database.GetService<IMediator>().DispatchDomainEventsAsync(this);
        var result = await base.SaveChangesAsync(cancellationToken);
        return true;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VaccinationSiteEntityConfiguration());
    }
}
