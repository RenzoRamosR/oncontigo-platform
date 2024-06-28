using oncontigo_platform.Scheduling.Domain.Model.ValueObjects;
using System;

namespace oncontigo_platform.Scheduling.Interfaces.REST.Resources;

public record AppointmentResource(long Id,long PatientId,long DoctorId,AppointmentDetails AppointmentDetails,DateTime AppointmentDate,DateTime CreatedAt)

