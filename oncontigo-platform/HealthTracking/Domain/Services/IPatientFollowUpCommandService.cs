using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;

namespace oncontigo_platform.HealthTracking.Domain.Services
{
    public interface IPatientFollowUpCommandService
    {
        Task<PatientFollowUp?> Handle(CreatePatientFollowUpCommand command);
        Task<PatientFollowUp?> Handle(RemovePatientFollowUpByPatientIdCommand command);
    }
}
