using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Domain.Model.Entities
{
    public partial class Medicine
    {
        public int Id { get; set; }
        public MedicineInformation MedicineInformation { get; private set; }
        public Medicine(string medicineName, string medicineDescription) 
        { 
            MedicineInformation = new MedicineInformation(medicineName, medicineDescription);
        }
    }
}
