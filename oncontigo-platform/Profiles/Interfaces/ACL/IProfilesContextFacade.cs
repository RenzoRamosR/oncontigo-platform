namespace oncontigo_platform.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country);

    Task<int> FetchProfileIdByEmail(string email);

    Task<int> FetchDoctorIdById(int doctorId);

    Task<int> FetchPatientIdById(int patientId);
}
