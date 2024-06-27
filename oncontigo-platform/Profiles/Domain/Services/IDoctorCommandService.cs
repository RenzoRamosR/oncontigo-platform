using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Commands;

namespace oncontigo_platform.Profiles.Domain.Services;

public interface IDoctorCommandService
{
    Task<Doctor?> Handle(CreateDoctorCommand command);
}
