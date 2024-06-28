using Microsoft.EntityFrameworkCore;
using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;

namespace oncontigo_platform.HealthTracking.Infrastructure
{
    public class MedicineRepository(AppDbContext context) : BaseRepository<Medicine>(context), IMedicineRepository
    {
        public async Task<IEnumerable<Medicine>> ListByPatientFollowUpId(int patientFollowUpId)
        {
            return await Context.Set<Medicine>().Where(p => p.PatientFollowUpId == patientFollowUpId).ToListAsync();
        }
    }
}
