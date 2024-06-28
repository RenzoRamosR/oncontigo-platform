using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;
using oncontigo_platform.HealthTracking.Interfaces.REST.Transformers;

namespace oncontigo_platform.HealthTracking.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/medicines")]
    public class MedicinesController(IMedicineCommandService medicineCommandService, IMedicineQueryService medicineQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateMedicineResource createMedicineResource)
        {
            var createMedicineCommand = CreateMedicineCommandFromResourceAssembler.ToCommandFromResource(createMedicineResource);
            var request = await medicineCommandService.Handle(createMedicineCommand);
            if (request == null) { return BadRequest(); }
            var medicineResource = MedicineResourceFromEntityAssembler.ToResourceFromEntity(request);
            return Ok(medicineResource);
        }

        [HttpDelete("{medicineId}")]
        public async Task<IActionResult> RemoveRequest([FromRoute] int medicineId)
        {
            var removeMedicineById = new RemoveMedicineByIdCommand(medicineId);
            var medicineDeleted = await medicineCommandService.Handle(removeMedicineById);
            if (medicineDeleted == null) { return BadRequest(); }
            var medicineResource = MedicineResourceFromEntityAssembler.ToResourceFromEntity(medicineDeleted);
            return Ok(medicineResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            var getAllMedicinesQuery = new GetAllMedicinesQuery();
            var medicines = await medicineQueryService.Handle(getAllMedicinesQuery);
            var resources = medicines.Select(MedicineResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpPut("{medicineId}")]
        public async Task<IActionResult> UpdateMedicineById([FromRoute] int medicineId, [FromBody] UpdateMedicineResource resource)
        {
            var updateMedicineById = UpdateMedicineByIdCommandFromResourceAssembler.ToCommandFromResource(medicineId, resource);
            var request = await medicineCommandService.Handle(updateMedicineById);
            if (request == null) { return BadRequest(); }
            var medicineResource = MedicineResourceFromEntityAssembler.ToResourceFromEntity(request);
            return Ok(medicineResource);
        }
    }
}
