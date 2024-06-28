using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;
using oncontigo_platform.HealthTracking.Domain.Repositories;
using oncontigo_platform.HealthTracking.Domain.Services;

namespace oncontigo_platform.HealthTracking.Application.Internal.QueryServices
{
    public class MedicineQueryService(IMedicineRepository medicineRepository): IMedicineQueryService
    {
        public async Task<IEnumerable<Medicine>> Handle(GetAllMedicinesQuery query)
        {
            return await medicineRepository.ListAsync();
        }
    }
}
