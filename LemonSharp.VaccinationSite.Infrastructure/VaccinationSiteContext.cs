using LemonSharp.VaccinationSite.Domain.SeedWork;
using LemonSharp.VaccinationSite.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LemonSharp.VaccinationSite.Infrastructure;

public class VaccinationSiteContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public DbSet<Domain.AggregatesModel.VaccinationSiteAggregate.Site> Sites { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlServer(
    //         "Server=tcp:lemon-sharp.database.windows.net,1433;Initial Catalog=reservation;Persist Security Info=False;User ID=lemon;Password=Test@123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;database=VaccinationSite");

    public VaccinationSiteContext(DbContextOptions<VaccinationSiteContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
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
