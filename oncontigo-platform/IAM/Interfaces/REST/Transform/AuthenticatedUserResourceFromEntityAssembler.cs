using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Interfaces.REST.Resources;

namespace oncontigo_platform.IAM.Interfaces.REST.Transform;
public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Email, token);
    }
}