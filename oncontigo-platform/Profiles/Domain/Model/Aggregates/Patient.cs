using oncontigo_platform.Profiles.Domain.Model.Commands;

namespace oncontigo_platform.Profiles.Domain.Model.Aggregates;

public partial class Patient
{

    public Patient()
    {
        Id = 0;
    }

    public Patient(int id)
    {
        Id = id;
    }

    public Patient(CreatePatientCommand command)
    {
        Id = command.UserId;
    }

    public int Id { get; }

}
