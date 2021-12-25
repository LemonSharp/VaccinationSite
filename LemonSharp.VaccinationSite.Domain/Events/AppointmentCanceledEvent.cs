using MediatR;

namespace LemonSharp.VaccinationSite.Domain.Events;

public record AppointmentCanceledEvent(
    long UserId,
    DateTime AppointmentDate
) : INotification;
