using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Domain.Model.Queries;
using oncontigo_platform.IAM.Domain.Repositories;
using oncontigo_platform.IAM.Domain.Services;

namespace oncontigo_platform.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
}