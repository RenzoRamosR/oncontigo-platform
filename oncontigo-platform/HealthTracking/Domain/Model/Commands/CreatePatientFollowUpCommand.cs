using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Domain.Model.Commands
{
    public record CreatePatientFollowUpCommand(int patientId, int doctorId, EStatus status);

}
