using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}
