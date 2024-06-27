using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Repositories;
using oncontigo_platform.Profiles.Domain.Services;

namespace oncontigo_platform.Profiles.Application.QueryServices;

public class DoctorQueryService(IDoctorRepository doctorRepository) : IDoctorQueryService
{
    public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query)
    {
        return await doctorRepository.ListAsync();
    }

    public async Task<Doctor?> Handle(GetDoctorByIdQuery query)
    {
        return await doctorRepository.FindByIdAsync(query.DoctorId);
    }
 }