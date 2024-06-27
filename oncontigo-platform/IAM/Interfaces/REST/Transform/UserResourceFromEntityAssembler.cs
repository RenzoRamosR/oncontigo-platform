using oncontigo_platform.IAM.Domain.Model.Aggregates;
using oncontigo_platform.IAM.Interfaces.REST.Resources;

namespace oncontigo_platform.IAM.Interfaces.REST.Transform;
public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Email);
    }
}
