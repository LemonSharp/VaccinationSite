using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;
using LemonSharp.VaccinationSite.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace LemonSharp.VaccinationSite.Infrastructure.Repositories;

public class SiteRepository : ISiteRepository
{
    private readonly VaccinationSiteContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public SiteRepository(VaccinationSiteContext context)
    {
        _context = context;
    }

    public Site Add(Site site)
    {
        _context.Sites.Add(site);
        return site;
    }

    public Task<Site> GetAsync(Guid id)
    {
        var site = _context.Sites
            .Include(s => s.AppointmentRanges)
            .SingleOrDefaultAsync(s => s.Id == id);

        return site;
    }
}
