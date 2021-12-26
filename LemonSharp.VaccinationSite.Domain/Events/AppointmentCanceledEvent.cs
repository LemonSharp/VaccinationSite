namespace LemonSharp.VaccinationSite.Domain.Events;

public record AppointmentCanceledEvent(
    Guid UserId,
    DateTime AppointmentDate
) : IDomainEvent;
