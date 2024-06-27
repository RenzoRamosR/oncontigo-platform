using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;

namespace oncontigo_platform.Profiles.Interfaces.REST.Transform;

public static class CreatePatientCommandFromResourceAssembler
{
    public static CreatePatientCommand ToCommandFromResource(CreatePatientResource resource)
    {
        return new CreatePatientCommand(resource.Id);
    }
}
