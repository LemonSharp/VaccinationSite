using LemonSharp.VaccinationSite.Domain.SeedWork;

namespace LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;

public interface ISiteRepository : IRepository<Site>
{
    Site Add(Site site);

    Task<Site> GetAsync(int id);
}
