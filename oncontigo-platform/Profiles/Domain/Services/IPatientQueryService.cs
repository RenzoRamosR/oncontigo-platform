using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Queries;

namespace oncontigo_platform.Profiles.Domain.Services;

public interface IPatientQueryService
{
    Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query);
    Task<Patient?> Handle(GetPatientByIdQuery query);
}
