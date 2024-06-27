using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;
using oncontigo_platform.HealthTracking.Interfaces.REST.Transformers;

namespace oncontigo_platform.HealthTracking.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/medicines")]
    public class MedicineController(IMedicineCommandService medicineCommandService, IMedicineQueryService medicineQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateMedicineResource createMedicineResource)
        {
            var createMedicineCommand = CreateMedicineCommandFromResourceAssembler.ToCommandFromResource(createMedicineResource);
            var request = await medicineCommandService.Handle(createMedicineCommand);
            if (request == null) { return BadRequest();}
            var medicineResource = MedicineResourceFromEntityAssembler.ToResourceFromEntity(request);
            return Ok(medicineResource);
        }
    }
}
