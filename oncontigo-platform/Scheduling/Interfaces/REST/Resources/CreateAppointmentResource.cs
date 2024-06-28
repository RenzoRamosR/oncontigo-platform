using oncontigo_platform.Scheduling.Domain.Model.ValueObjects;

using oncontigo_platform.Scheduling.Domain.Model.ValueObjects.AppointmentDetails;
using System;

namespace oncontigo_platform.Scheduling.Interfaces.REST.Resources;

public record CreateAppointmentResource(long patientId, long doctorId, AppointmentDetails appointmentDetails, DateTime appointmentDate);
   
