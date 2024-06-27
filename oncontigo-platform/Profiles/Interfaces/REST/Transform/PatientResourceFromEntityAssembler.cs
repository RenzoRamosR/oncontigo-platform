using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;

namespace oncontigo_platform.Profiles.Interfaces.REST.Transform;

public static class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity)
    {
        return new PatientResource(entity.Id);
    }
}
