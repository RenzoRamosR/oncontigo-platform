using oncontigo_platform.HealthTracking.Application.Internal.OutbondServices.ACL;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.HealthTracking.Infrastructure;
using oncontigo_platform.Shared.Domain.Repositories;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using System.Runtime.CompilerServices;

namespace oncontigo_platform.HealthTracking.Application.Internal.CommandServices
{
    public class MedicineCommandService(IMedicineRepository medicineRepository,IPatientFollowUpRepository patientFollowUpRepository, IUnitOfWork unitOfWork):IMedicineCommandService
    {
    
        public async Task<Medicine?> Handle(CreateMedicineCommand command)
        {
            var patientFollowUp = await patientFollowUpRepository.FindByIdAsync(command.PatientFollowUpId);

            if (patientFollowUp == null)
            {
                throw new InvalidOperationException("Patient follow-up not found.");
            }
            var medicine = new Medicine(command.MedicineName, command.MedicineDescription, patientFollowUp.Id);
            await medicineRepository.AddAsync(medicine);
            await unitOfWork.CompleteAsync();
            return medicine;
        }

        public async Task<Medicine?> Handle(RemoveMedicineByIdCommand command)
        {
            var medicine = await medicineRepository.FindByIdAsync(command.Id);
            if (medicine == null)
            {
                return null;
            }

            medicineRepository.Remove(medicine);
            await unitOfWork.CompleteAsync();
            return medicine;

        }
        public async Task<Medicine?> Handle(UpdateMedicineByIdCommand command)
        {
            var medicine = await medicineRepository.FindByIdAsync(command.Id);
            if (medicine == null)
            {
                return null;
            }

            medicine.UpdateDetails(command.MedicineName, command.MedicineDescription);
            medicineRepository.Update(medicine);
            await unitOfWork.CompleteAsync();
            return medicine;
        
        }
}
}
