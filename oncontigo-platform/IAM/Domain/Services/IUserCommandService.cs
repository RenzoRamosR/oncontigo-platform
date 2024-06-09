using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Domain.Model.Commands;

namespace oncontigo_platform.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}