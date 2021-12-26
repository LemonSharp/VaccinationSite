using LemonSharp.VaccinationSite.Application.AppServices;
using LemonSharp.VaccinationSite.Application.DTOs;
using LemonSharp.VaccinationSite.Query;
using LemonSharp.VaccinationSite.Query.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LemonSharp.VaccinationSite.API.Controllers;

[Route("/api/[controller]/[action]")]
public class SiteController : Controller
{
    private readonly ISiteAppService _siteAppService;
    private readonly ISiteQueries _siteQueries;

    public SiteController(ISiteAppService siteAppService, ISiteQueries siteQueries)
    {
        _siteAppService = siteAppService;
        _siteQueries = siteQueries;
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

    [HttpGet]
    public Task<SiteListDTO[]> List([FromQuery]SiteListRequestDTO request)
    {
        return _siteQueries.GetSiteListAsync(request);
    }
    
    [HttpGet("{siteId}")]
    public Task<SiteListDTO> Details(Guid siteId)
    {
        return _siteQueries.GetSiteInfoByIdAsync(siteId);
    }

    [HttpGet]
    public Task<SiteCapacityResponseDTO[]> SiteCapacityInfo([FromQuery] SiteCapacityRequestDTO request)
    {
        return _siteQueries.GetSiteCapacityInfoAsync(request);
    }
}
