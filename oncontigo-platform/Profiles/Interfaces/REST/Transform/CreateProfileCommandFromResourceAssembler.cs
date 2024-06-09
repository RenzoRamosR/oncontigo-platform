using oncontigo_platform.Profiles.Interfaces.REST.Resources;
using oncontigo_platform.Profiles.Domain.Model.Commands;

namespace oncontigo_platform.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}