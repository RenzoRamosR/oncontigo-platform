using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.Profiles.Application.Internal.CommandServices;
using oncontigo_platform.Profiles.Application.Internal.QueryServices;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;
using oncontigo_platform.Profiles.Interfaces.REST.Transform;
using System.Net.Mime;

namespace oncontigo_platform.Profiles.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PatientsController(IPatientCommandService patientCommandService, IPatientQueryService patientQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePatient(CreatePatientResource resource)
    {
        var createPatientCommand = CreatePatientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var patient = await patientCommandService.Handle(createPatientCommand);
        if (patient is null) return BadRequest();
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return CreatedAtAction(nameof(GetPatientById), new { patientId = patientResource.Id }, patientResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var getAllPatientsQuery = new GetAllPatientsQuery();
        var patients = await patientQueryService.Handle(getAllPatientsQuery);
        var patientResources = patients.Select(PatientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(patientResources);
    }

    [HttpGet("{patientId:int}")]
    public async Task<IActionResult> GetPatientById(int patientId)
    {
        var getPatientByIdQuery = new GetPatientByIdQuery(patientId);
        var patient = await patientQueryService.Handle(getPatientByIdQuery);
        if (patient == null) return NotFound();
        var patientResource = PatientResourceFromEntityAssembler.ToResourceFromEntity(patient);
        return Ok(patientResource);
    }
}
