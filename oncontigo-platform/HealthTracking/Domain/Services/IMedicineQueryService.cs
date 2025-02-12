﻿using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;

namespace oncontigo_platform.HealthTracking.Domain.Services
{
    public interface IMedicineQueryService
    {
        Task<IEnumerable<Medicine>> Handle(GetAllMedicinesQuery query);
        Task<IEnumerable<Medicine>> Handle(GetAllMedicinesByPatientFollowUpIdQuery query);
    }
}
