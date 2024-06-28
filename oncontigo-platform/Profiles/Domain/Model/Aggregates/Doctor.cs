using oncontigo_platform.Profiles.Domain.Model.Commands;
using Org.BouncyCastle.Bcpg;

namespace oncontigo_platform.Profiles.Domain.Model.Aggregates;
public partial class Doctor
{
    public Doctor()
    {
        Id = 0;
    }

    public Doctor(int id)
    {
        Id = id;
    }

    public Doctor(CreateDoctorCommand command)
    {
        Id = command.UserId;
    }

    public int Id { get; }
}
