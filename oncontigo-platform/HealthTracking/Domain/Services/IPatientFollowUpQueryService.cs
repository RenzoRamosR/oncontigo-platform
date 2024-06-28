using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;

namespace oncontigo_platform.HealthTracking.Domain.Services
{
    public interface IPatientFollowUpQueryService
    {
        Task<IEnumerable<PatientFollowUp>> Handle(GetAllPatientFollowUpsByDoctorIdQuery query);
    }
}
