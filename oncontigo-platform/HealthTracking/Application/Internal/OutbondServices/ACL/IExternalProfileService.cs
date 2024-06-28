using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Application.Internal.OutbondServices.ACL
{
    public interface IExternalProfileService
    {
        Task<DoctorId?> FetchDoctorIdById(int doctorId);

        Task<PatientId?> FetchPatientIdById(int patientId);
    }
}
