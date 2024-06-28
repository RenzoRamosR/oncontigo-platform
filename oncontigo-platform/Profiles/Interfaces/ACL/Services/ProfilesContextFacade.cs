using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Model.ValueObjects;
using oncontigo_platform.Profiles.Application.QueryServices;

namespace oncontigo_platform.Profiles.Interfaces.ACL.Services;


public class ProfilesContextFacade(IProfileCommandService profileCommandService,IPatientQueryService patientQueryService, IProfileQueryService profileQueryService, IDoctorQueryService doctorQueryService) : IProfilesContextFacade
{
    
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string street, string number, string city, string postalCode, string country)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, street, number, city, postalCode, country);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }

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
