using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;
using System.Diagnostics.Eventing.Reader;

namespace oncontigo_platform.HealthTracking.Domain.Model.Aggregates
{
    public partial class PatientFollowUp
    {
        public int Id { get; }

        public PatientId PatientId { get; set; }

        public DoctorId DoctorId { get; set; }

        public EStatus Status { get; set; }

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();


        public PatientFollowUp()
        {
           
        }
        public PatientFollowUp(int patientId, int doctorId, EStatus status)
        {
            PatientId = new PatientId(patientId);
            DoctorId = new DoctorId(doctorId);
            Status = status;
        }
        public PatientFollowUp(CreatePatientFollowUpCommand command)
        {
            PatientId = new PatientId(command.patientId);
            DoctorId = new DoctorId(command.doctorId);
            Status = command.status;
        }
    }
}
