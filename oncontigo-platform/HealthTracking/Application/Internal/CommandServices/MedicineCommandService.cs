using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.Shared.Domain.Repositories;

namespace oncontigo_platform.HealthTracking.Application.Internal.CommandServices
{
    public class MedicineCommandService(IMedicineRepository medicineRepository,IUnitOfWork unitOfWork):IMedicineCommandService
    {
        public async Task<Medicine?> Handle(CreateMedicineCommand command)
        {
            var medicine = new Medicine(command.MedicineName, command.MedicineDescription);
            await medicineRepository.AddAsync(medicine);
            return medicine;
        }
    }
}
