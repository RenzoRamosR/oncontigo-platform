namespace oncontigo_platform.Scheduling.Interfaces.REST.Transformers;

using oncontigo_platform.Scheduling.Application.Commands.CreateAppointmentCommand;
using oncontigo_platform.Scheduling.Interfaces.REST.Resources.CreateAppointmentResource;

public class CreateAppointmentCommandFromResourceAssembler
{
    public CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource resource)
    {
        return new CreateAppointmentCommand(
            resource.PatientId(),
            resource.DoctorId(),
            resource.AppointmentDetails(),
            resource.AppointmentDate()
        );
    }


}
