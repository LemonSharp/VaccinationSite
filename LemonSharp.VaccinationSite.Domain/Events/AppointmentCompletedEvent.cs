namespace LemonSharp.VaccinationSite.Domain.Events;

public record AppointmentCompletedEvent(
    Guid UserId,
    DateTime AppointmentDate,
    string AddressName,
    double AddressLongitude,
    double AddressLatitude
) : IDomainEvent;
