using LemonSharp.VaccinationSite.Application.AppServices;
using LemonSharp.VaccinationSite.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationSite.API.Controllers;

[Route("/api/[controller]/[action]")]
public class SiteController : Controller
{
    private readonly ISiteAppService _siteAppService;

    public SiteController(ISiteAppService siteAppService)
    {
        _siteAppService = siteAppService;
    }

    [HttpPost]
    public Task<BusinessResult> AddNewSite([FromBody] AddSiteRequestDTO request)
    {
        return _siteAppService.AddSiteAsync(request);
    }
    
    [HttpPost]
    public Task<BusinessResult> CreateAppointment([FromBody] CreateAppointmentDTO request)
    {
        return _siteAppService.CreateAppointment(request);
    }
    
    [HttpPost]
    public Task<BusinessResult> CancelAppointment([FromBody] CancelAppointmentDTO request)
    {
        return _siteAppService.CancelAppointment(request);
    }
}
