namespace LemonSharp.VaccinationSite.Application.DTOs;

public record CreateAppointmentDTO(Guid SiteId, Guid UserId, DateTime Date);
