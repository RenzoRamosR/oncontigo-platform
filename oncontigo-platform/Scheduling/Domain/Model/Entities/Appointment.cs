using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.ValueObjects;

namespace oncontigo_platform.Scheduling.Domain.Model.Entities
{
    public partial class Appointment
    {
        public int Id { get; }

        public PatientFollowUpId StatusId { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
