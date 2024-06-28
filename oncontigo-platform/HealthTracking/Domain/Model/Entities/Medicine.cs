using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.HealthTracking.Domain.Model.Entities
{
    public partial class Medicine
    {
        public int Id { get; private set; }
        public MedicineInformation Information { get; private set; }

        public int PatientFollowUpId { get; private set; }

        public PatientFollowUp PatientFollowUp { get; private set; }

        // Constructor sin argumentos para EF Core
        private Medicine() {
            Information = new MedicineInformation(string.Empty, string.Empty);
            PatientFollowUpId = 0;
        }

        public Medicine(string name, string description, int patientFollowUpId)
        {
            Information = new MedicineInformation(name, description);
            PatientFollowUpId = patientFollowUpId;
        }

        public Medicine(CreateMedicineCommand command) : this(command.MedicineName, command.MedicineDescription, command.PatientFollowUpId)
        {
            // Puedes agregar más lógica aquí si es necesario
        }

        public void UpdateDetails(string newName, string newDescription)
        {
            Information = new MedicineInformation(newName, newDescription);
        }
    }
}
