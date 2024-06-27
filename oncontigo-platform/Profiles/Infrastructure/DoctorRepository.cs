using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;

namespace oncontigo_platform.Profiles.Infrastructure;

public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
}
