using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Model.ValueObjects;
using oncontigo_platform.Profiles.Application.QueryServices;

namespace oncontigo_platform.Profiles.Interfaces.ACL.Services;


public class ProfilesContextFacade(IPatientQueryService patientQueryService, IDoctorQueryService doctorQueryService) : IProfilesContextFacade
{
    public async Task<int> FetchDoctorIdById(int doctorId)
    {
        var getDoctorByIdQuery = new GetDoctorByIdQuery(doctorId);
        var doctor = await doctorQueryService.Handle(getDoctorByIdQuery);
        return doctor?.Id ?? 0;
    }
    public async Task<int> FetchPatientIdById(int patientId)
    {
        var getPatientByIdQuery = new GetPatientByIdQuery(patientId);
        var patient = await patientQueryService.Handle(getPatientByIdQuery);
        return patient?.Id ?? 0;
    }

}
