using LemonSharp.VaccinationSite.Query.DTOs;

namespace LemonSharp.VaccinationSite.Query;

public interface ISiteQueries
{
    Task<SiteListDTO[]> GetSiteList(SiteListRequestDTO request);
    Task<SiteListDTO> GetSiteInfoById(Guid siteId);

    Task<SiteCapacityResponseDTO[]> GetSiteCapacityInfo(SiteCapacityRequestDTO request);
}
