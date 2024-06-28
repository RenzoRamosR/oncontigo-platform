namespace oncontigo_platform.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
   
    Task<int> FetchDoctorIdById(int doctorId);

    Task<int> FetchPatientIdById(int patientId);
}
