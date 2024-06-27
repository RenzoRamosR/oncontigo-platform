using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace oncontigo_platform.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> FindByEmailAsync(string email)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public bool ExistsByEmail(string email)
        {
            return Context.Set<User>().Any(user => user.Email.Equals(email));
        }
    }
}
