using LemonSharp.VaccinationSite.Domain.SeedWork;
using LemonSharp.VaccinationSite.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LemonSharp.VaccinationSite.Infrastructure;

public class VaccinationSiteContext : DbContext, IUnitOfWork
{
    public DbSet<Domain.AggregatesModel.VaccinationSiteAggregate.Site> Sites { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlServer(
    //         "Server=tcp:lemon-sharp.database.windows.net,1433;Initial Catalog=reservation;Persist Security Info=False;User ID=lemon;Password=Test@123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;database=VaccinationSite");

    public VaccinationSiteContext(DbContextOptions<VaccinationSiteContext> options) : base(options)
    {
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Entity entity && entity.IsTransient())
            {
                entry.State = EntityState.Added;
            }
        }
        
        var result = await base.SaveChangesAsync(cancellationToken);
        
        var domainEntities = ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            // TODO PUBSUB
        }
        return true;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VaccinationSiteEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentRangeEntityConfiguration());
    }
}
