using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.HealthTracking.Application.Internal.CommandServices;
using oncontigo_platform.HealthTracking.Domain.Model.Aggregates;
using oncontigo_platform.HealthTracking.Domain.Model.Commands;
using oncontigo_platform.HealthTracking.Domain.Model.Entities;
using oncontigo_platform.HealthTracking.Domain.Model.Queries;
using oncontigo_platform.HealthTracking.Domain.Services;
using oncontigo_platform.HealthTracking.Interfaces.REST.Resources;
using oncontigo_platform.HealthTracking.Interfaces.REST.Transformers;

namespace oncontigo_platform.HealthTracking.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/patientFollowUp")]
    public class PatientFollowUpController(IPatientFollowUpCommandService patientFollowUpCommandService, IPatientFollowUpQueryService patientFollowUpQueryService) : ControllerBase
    {
        [HttpGet("by-doctorId/{doctorId}")]
        public async Task<IActionResult> GetAllPatientFollowUpsByDoctorId(int doctorId)
        {
            var patientFollowUp = await patientFollowUpQueryService.Handle(new GetAllPatientFollowUpsByDoctorIdQuery(doctorId));
            if (patientFollowUp == null) { return NotFound(); }
            var resource = patientFollowUp.Select(PatientFollowUpFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientFollowUp([FromBody] CreatePatientFollowUpResource createPatientResource)
        {
            var createPatientFollowUp = CreatePatientFollowUpCommandFromResourceAssembler.ToCommandFromResource(createPatientResource);
            var patientFollowUp = await patientFollowUpCommandService.Handle(createPatientFollowUp);
            if (patientFollowUp is null) return BadRequest();
            var resource = PatientFollowUpFromEntityAssembler.ToResourceFromEntity(patientFollowUp);
            return Ok(resource);
        }

        [HttpDelete("by-patientId/{patientId}")]
        public async Task<IActionResult> RemovePatientFollowUpByPatientId([FromRoute] int patientId)
        {
            var removeMedicineById = new RemovePatientFollowUpByPatientIdCommand(patientId);
            var patientFollowUp = await patientFollowUpCommandService.Handle(removeMedicineById);
            if (patientFollowUp == null) { return BadRequest(); }
            var followUpDeletedResource = PatientFollowUpFromEntityAssembler.ToResourceFromEntity(patientFollowUp);
            return Ok(followUpDeletedResource);
        }
    }
}
