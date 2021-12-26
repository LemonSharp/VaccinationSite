using LemonSharp.VaccinationSite.Query.DTOs;

namespace LemonSharp.VaccinationSite.Query;

public interface ISiteQueries
{
    Task<SiteListDTO[]> GetSiteList(SiteListRequestDTO request);

    Task<SiteCapacityResponseDTO[]> GetSiteCapacityInfo(SiteCapacityRequestDTO request);
}
