using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;

namespace oncontigo_platform.Profiles.Interfaces.REST.Transform;

public class DoctorResourceFromEntityAssembler
{
    public static DoctorResource ToResourceFromEntity(Doctor entity)
    {
        return new DoctorResource(entity.Id);
    }
}
