using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;

namespace oncontigo_platform.HealthTracking.Interfaces.REST.Transformers
{
    public class CreateMedicineCommandFromResourceAssembler
    {
        public static CreateMedicineCommand ToCommandFromResource(CreateMedicineResource resource)
        {
            return new CreateMedicineCommand(resource.medicineName, resource.medicineDescription);
        }
    }
}
