using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Domain.Repositories;
using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Infrastructure;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.Profiles.Application.CommandServices;

public class DoctorCommandService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork) : IDoctorCommandService
{
    public async Task<Doctor?> Handle(CreateDoctorCommand command)
    {
        var doctor = new Doctor(command);
        try
        {
            await doctorRepository.AddAsync(doctor);
            await unitOfWork.CompleteAsync();
            return doctor;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}
