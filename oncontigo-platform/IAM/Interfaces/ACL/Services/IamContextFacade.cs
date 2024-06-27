using oncontigo_platform.IAM.Domain.Model.Commands;
using oncontigo_platform.IAM.Domain.Model.Queries;
using oncontigo_platform.IAM.Domain.Services;

namespace oncontigo_platform.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(string email, string password)
    {
        var signUpCommand = new SignUpCommand(email, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByEmail(string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchEmailByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Email ?? string.Empty;
    }
}
