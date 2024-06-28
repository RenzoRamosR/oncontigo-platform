using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;
using oncontigo_platform.Profiles.Interfaces.ACL;

namespace oncontigo_platform.HealthTracking.Application.Internal.OutbondServices.ACL
{
    public class ExternalProfileService(IProfilesContextFacade profilesContextFacade):IExternalProfileService
    {
        public async Task<DoctorId?> FetchDoctorIdById(int doctorId)
        {
            var Id = await profilesContextFacade.FetchDoctorIdById(doctorId);
            if(Id ==0) { return await Task.FromResult<DoctorId?>(null); }
            return new DoctorId(Id);
        }
        public async Task<PatientId?> FetchPatientIdById(int patientId)
        {
            var Id = await profilesContextFacade.FetchDoctorIdById(patientId);
            if (Id == 0) { return await Task.FromResult<PatientId?>(null); }
            return new PatientId(Id);
        }
    }
}
