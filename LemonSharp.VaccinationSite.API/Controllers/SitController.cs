using LemonSharp.VaccinationSite.Application.AppServices;
using LemonSharp.VaccinationSite.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationSite.API.Controllers;

[Route("/api/[controller]/[action]")]
public class SitController : Controller
{
    private readonly ISiteAppService _siteAppService;

    public SitController(ISiteAppService siteAppService)
    {
        _siteAppService = siteAppService;
    }

    [HttpPost]
    public Task<BusinessResult> AddNewSite([FromBody] AddSiteRequestDTO request)
    {
        return _siteAppService.AddSiteAsync(request);
    }
}
