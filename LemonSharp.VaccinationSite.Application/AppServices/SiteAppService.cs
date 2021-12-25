using LemonSharp.VaccinationSite.Application.DTOs;
using LemonSharp.VaccinationSite.Domain;
using LemonSharp.VaccinationSite.Domain.AggregatesModel.VaccinationSiteAggregate;

namespace LemonSharp.VaccinationSite.Application.AppServices;

public class SiteAppService : ISiteAppService
{
    private readonly ISiteRepository _siteRepository;

    public SiteAppService(ISiteRepository siteRepository)
    {
        _siteRepository = siteRepository;
    }

    public async Task<BusinessResult> AddSiteAsync(AddSiteRequestDTO request)
    {
        var site = new Site(
            request.SiteName,
            request.AddressName,
            request.AddressLatitude, request.AddressLongitude,
            request.Capacity);
        _siteRepository.Add(site);
        await _siteRepository.UnitOfWork.SaveEntitiesAsync();

        return new BusinessResult(BusinessCode.Success, "新增接种点成功");
    }

    // TODO create app
}
