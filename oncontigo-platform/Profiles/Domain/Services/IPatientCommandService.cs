using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Commands;

namespace oncontigo_platform.Profiles.Domain.Services;

public interface IPatientCommandService
{
    Task<Patient?> Handle(CreatePatientCommand command);
}
