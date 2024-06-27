using oncontigo_platform.Profiles.Domain.Model.Aggregates;
using oncontigo_platform.Profiles.Domain.Model.Commands;
using oncontigo_platform.Profiles.Domain.Repositories;
using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.Profiles.Application.CommandServices;

public class PatientCommandService(IPatientRepository patientRepository, IUnitOfWork unitOfWork) : IPatientCommandService
{
    public async Task<Patient?> Handle(CreatePatientCommand command)
    {
        var patient = new Patient(command);
        try
        {
            await patientRepository.AddAsync(patient);
            await unitOfWork.CompleteAsync();
            return patient;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}
