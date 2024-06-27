using oncontigo_platform.IAM.Application.Internal.OutboundServices;
using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Domain.Model.Commands;
using oncontigo_platform.IAM.Domain.Repositories;
using oncontigo_platform.IAM.Domain.Services;
using oncontigo_platform.Shared.Domain.Repositories;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
    ) : IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByEmail(command.Email))
            throw new Exception($"Email {command.Email} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Email, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);

        if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
}
