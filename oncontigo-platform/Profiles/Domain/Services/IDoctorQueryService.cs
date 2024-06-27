using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Queries;

namespace oncontigo_platform.Profiles.Domain.Services;

public interface IDoctorQueryService
{
    Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query);
    Task<Doctor?> Handle(GetDoctorByIdQuery query);
}
