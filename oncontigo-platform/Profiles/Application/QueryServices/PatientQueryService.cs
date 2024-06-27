using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Repositories;
using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Infrastructure.Persistence.EFC.Repositories;

namespace oncontigo_platform.Profiles.Application.QueryServices;

public class PatientQueryService(IPatientRepository patientRepository) : IPatientQueryService
{
    public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query)
    {
        return await patientRepository.ListAsync();
    }

    public async Task<Patient?> Handle(GetPatientByIdQuery query)
    {
        return await patientRepository.FindByIdAsync(query.PatientId);
    }
}
