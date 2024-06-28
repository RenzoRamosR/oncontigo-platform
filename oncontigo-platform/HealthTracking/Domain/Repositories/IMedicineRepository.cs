using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.HealthTracking.Domain.Repositories
{
    public interface IMedicineRepository:IBaseRepository<Medicine>
    {
        Task<IEnumerable<Medicine>> ListByPatientFollowUpId(int patientFollowUpId);
    }
}
