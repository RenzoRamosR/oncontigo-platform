using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Domain.Model.Queries;

namespace oncontigo_platform.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}
