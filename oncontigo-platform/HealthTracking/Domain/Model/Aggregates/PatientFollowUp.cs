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
            PatientId = new PatientId(0);
            DoctorId = new DoctorId(0);
        }
        public PatientFollowUp(PatientId patientId, DoctorId doctorId, EStatus status)
        {
            PatientId = patientId;
            DoctorId = doctorId;
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
