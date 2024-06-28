using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;

namespace oncontigo_platform.HealthTracking.Interfaces.REST.Transformers
{
    public class PatientFollowUpFromEntityAssembler
    {
        public static PatientFollowUpResource ToResourceFromEntity(PatientFollowUp patientFollowUp)
        {
            return new PatientFollowUpResource(patientFollowUp.PatientId.patientId, patientFollowUp.DoctorId.doctorId, (int) patientFollowUp.Status);
        }
    }
}
