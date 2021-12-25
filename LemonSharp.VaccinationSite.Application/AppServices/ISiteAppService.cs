using LemonSharp.VaccinationSite.Application.DTOs;

namespace LemonSharp.VaccinationSite.Application.AppServices;

public interface ISiteAppService
{
    Task<BusinessResult> AddSiteAsync(AddSiteRequestDTO request);
}
