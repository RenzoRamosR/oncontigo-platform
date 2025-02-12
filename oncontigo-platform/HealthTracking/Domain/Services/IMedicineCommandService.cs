﻿using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;

namespace oncontigo_platform.HealthTracking.Domain.Services
{
    public interface IMedicineCommandService
    {
        public Task<Medicine?> Handle(CreateMedicineCommand command);
        public Task<Medicine?> Handle(RemoveMedicineByIdCommand command);
        public Task<Medicine?> Handle(UpdateMedicineByIdCommand command);
    }
}
