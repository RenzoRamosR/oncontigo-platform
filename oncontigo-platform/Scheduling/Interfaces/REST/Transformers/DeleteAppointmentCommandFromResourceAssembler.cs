namespace oncontigo_platform.Scheduling.Interfaces.REST.Transformers;

using oncontigo_platform.Scheduling.Application.Commands.DeleteAppointmentCommand;

public class DeleteAppointmentCommandFromResourceAssembler
{
    public DeleteAppointmentCommand ToCommandFromResource(long id)
    {
        return new DeleteAppointmentCommand(id);
    }
}


