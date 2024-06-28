using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.HealthTracking.Domain.Repositories
{
    public interface IPatientFollowUpRepository : IBaseRepository<PatientFollowUp>
    {
        Task<PatientFollowUp?> FindByPatientId(int PatientId);
        Task<IEnumerable<PatientFollowUp>> ListByDoctorId(int DoctorId);
    }
}
