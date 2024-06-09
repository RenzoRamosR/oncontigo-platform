using oncontigo_platform.IAM.Domain.Model.Aggregates;

namespace oncontigo_platform.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}
