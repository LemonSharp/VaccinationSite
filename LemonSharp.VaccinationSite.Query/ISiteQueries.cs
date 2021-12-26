using LemonSharp.VaccinationSite.Query.DTOs;

namespace LemonSharp.VaccinationSite.Query;

public interface ISiteQueries
{
    Task<SiteListDTO> GetSiteInfoByIdAsync(Guid siteId);

    Task<SiteListDTO[]> GetSiteListAsync(SiteListRequestDTO request);

    Task<SiteCapacityResponseDTO[]> GetSiteCapacityInfoAsync(SiteCapacityRequestDTO request);
}
