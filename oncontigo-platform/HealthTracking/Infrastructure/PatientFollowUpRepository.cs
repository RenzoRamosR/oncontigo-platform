using Microsoft.EntityFrameworkCore;
using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;

namespace oncontigo_platform.HealthTracking.Infrastructure
{
    public class PatientFollowUpRepository(AppDbContext context) : BaseRepository<PatientFollowUp>(context), IPatientFollowUpRepository
    {
        public async Task<PatientFollowUp?> FindByPatientId(int PatientId)
        {
           return  await Context.Set<PatientFollowUp>().Where(p => p.PatientId.Id == PatientId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PatientFollowUp>> ListByDoctorId(int DoctorId)
        {
            return await Context.Set<PatientFollowUp>().Where(p=> p.DoctorId.Id == DoctorId).ToListAsync();
        }
    }
}
