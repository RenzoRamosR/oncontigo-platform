using oncontigo_platform.IAM.Domain.Model.Commands;
using oncontigo_platform.IAM.Interfaces.REST.Resources;

namespace oncontigo_platform.IAM.Interfaces.REST.Transform;
public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}
