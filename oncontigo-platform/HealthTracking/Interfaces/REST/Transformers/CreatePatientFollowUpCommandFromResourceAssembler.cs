using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;

namespace oncontigo_platform.HealthTracking.Interfaces.REST.Transformers
{
    public class CreatePatientFollowUpCommandFromResourceAssembler
    {
        public static CreatePatientFollowUpCommand ToCommandFromResource(CreatePatientFollowUpResource resource)
        {
            return new CreatePatientFollowUpCommand(resource.patientId, resource.doctorId, (EStatus)resource.status);
        }
    }
}
