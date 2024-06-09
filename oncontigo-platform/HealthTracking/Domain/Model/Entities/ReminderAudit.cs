using System.ComponentModel.DataAnnotations.Schema;

namespace oncontigo_platform.HealthTracking.Domain.Model.Entities
{
    public partial class Reminder
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
