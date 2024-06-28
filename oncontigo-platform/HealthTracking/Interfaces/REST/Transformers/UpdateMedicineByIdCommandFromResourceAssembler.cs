using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;

namespace oncontigo_platform.HealthTracking.Interfaces.REST.Transformers
{
    public class UpdateMedicineByIdCommandFromResourceAssembler
    {
        public static UpdateMedicineByIdCommand ToCommandFromResource(int medicineId ,UpdateMedicineResource resource)
        {
            return new UpdateMedicineByIdCommand(medicineId,resource.medicineName, resource.medicineDescription);
        }
    }
}
