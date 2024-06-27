using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;

namespace oncontigo_platform.Profiles.Interfaces.REST.Transform;

public static class CreateDoctorCommandFromResourceAssembler
{
    public static CreateDoctorCommand ToCommandFromResource(CreateDoctorResource resource)
    {
        return new CreateDoctorCommand(resource.Id);
    }
}
