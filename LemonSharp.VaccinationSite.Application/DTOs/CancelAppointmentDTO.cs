namespace LemonSharp.VaccinationSite.Application.DTOs;

public record CancelAppointmentDTO(Guid SiteId, Guid UserId, DateTime Date);
