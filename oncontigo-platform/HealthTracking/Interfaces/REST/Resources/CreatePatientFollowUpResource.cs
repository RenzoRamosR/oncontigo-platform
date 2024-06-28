using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Interfaces.REST.Resources
{
    public record CreatePatientFollowUpResource(int patientId, int doctorId, int status);
   
}
