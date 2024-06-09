using oncontigo_platform.Shared.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;

namespace oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
