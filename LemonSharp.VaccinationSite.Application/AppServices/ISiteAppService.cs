using LemonSharp.VaccinationSite.Application.DTOs;

namespace LemonSharp.VaccinationSite.Application.AppServices;

public interface ISiteAppService
{
    Task<BusinessResult> AddSiteAsync(AddSiteRequestDTO request);
    Task<BusinessResult> CreateAppointment(CreateAppointmentDTO request);
    Task<BusinessResult> CancelAppointment(CancelAppointmentDTO request);
}
