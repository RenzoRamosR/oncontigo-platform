namespace oncontigo_platform.Scheduling.Interfaces.REST.Transformers;

using oncontigo_platform.Scheduling.Domain.Entities.Appointment;
using oncontigo_platform.Scheduling.Interfaces.REST.Resources.AppointmentResource;


public class AppointmentResourceFromEntityAssembler
{
    public AppointmentResource ToResourceFromEntity(Appointment appointment)
    {
        return new AppointmentResource(
            appointment.Id,
            appointment.PatientId.PatientId,
            appointment.DoctorId.DoctorId,
            appointment.AppointmentDetails,
            appointment.Date,
            appointment.Date
        );
    }

}
