using System.ComponentModel.DataAnnotations.Schema;

namespace oncontigo_platform.HealthTracking.Domain.Model.Aggregates
{
    public partial class PatientFollowUp 
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
