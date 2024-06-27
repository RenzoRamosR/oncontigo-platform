using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
}
