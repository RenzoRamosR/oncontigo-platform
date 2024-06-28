namespace oncontigo_platform.HealthTracking.Interfaces.REST.Resources
{
    public record PatientFollowUpResource(int patientId, int doctorId, int status);
   
}
