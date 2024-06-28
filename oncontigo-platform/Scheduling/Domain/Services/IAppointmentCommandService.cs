using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Commands;

namespace oncontigo_platform.Scheduling.Domain.Services;

public class IAppointmentCommandService
{
    public Task<Appointment?> Handle(CreateAppointmentCommand command);
    public Task<Appointment?> Handle(RemoveAppointmentByIdCommand command);
    public Task<Appointment?> Handle(UpdateAppointmentByIdCommand command);
}
