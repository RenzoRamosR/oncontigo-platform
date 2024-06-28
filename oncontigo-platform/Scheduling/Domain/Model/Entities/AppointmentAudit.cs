using System.ComponentModel.DataAnnotations.Schema;

namespace oncontigo_platform.Scheduling.Domain.Model.Entities
{
    public partial class Appointment
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
