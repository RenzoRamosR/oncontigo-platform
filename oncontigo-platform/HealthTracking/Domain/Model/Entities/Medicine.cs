using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Domain.Model.Entities
{
    public partial class Medicine
    {
        public int Id { get; private set; }
        public MedicineInformation Information { get; private set; }

        // Constructor sin argumentos para EF Core
        private Medicine() { }

        public Medicine(string name, string description)
        {
            Information = new MedicineInformation(name, description);
        }

        public Medicine(CreateMedicineCommand command) : this(command.MedicineName, command.MedicineDescription)
        {
            // Puedes agregar más lógica aquí si es necesario
        }
    }
}
