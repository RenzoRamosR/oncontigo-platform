using oncontigo_platform.IAM.Domain.Model.Commands;
using oncontigo_platform.IAM.Interfaces.REST.Resources;

namespace oncontigo_platform.IAM.Interfaces.REST.Transform;
public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Email, resource.Password);
    }
}
