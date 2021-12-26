using LemonSharp.VaccinationSite.Query.DTOs;

namespace LemonSharp.VaccinationSite.Query;

public interface ISiteQueries
{
    Task<SiteListDTO[]> GetSiteListAsync(SiteListRequestDTO request);

    Task<SiteCapacityResponseDTO[]> GetSiteCapacityInfoAsync(SiteCapacityRequestDTO request);
}
