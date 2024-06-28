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
public class DoctorsController(IDoctorCommandService doctorCommandService, IDoctorQueryService doctorQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDoctor(CreateDoctorResource resource)
    {
        var createDoctorCommand = CreateDoctorCommandFromResourceAssembler.ToCommandFromResource(resource);
        var doctor = await doctorCommandService.Handle(createDoctorCommand);
        if (doctor is null) return BadRequest();
        var doctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
        return CreatedAtAction(nameof(GetDoctorById), new { doctorId = doctorResource.Id }, doctorResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var getAllDoctorsQuery = new GetAllDoctorsQuery();
        var doctors = await doctorQueryService.Handle(getAllDoctorsQuery);
        var doctorResources = doctors.Select(DoctorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(doctorResources);
    }

    [HttpGet("{doctorId:int}")]
    public async Task<IActionResult> GetDoctorById(int doctorId)
    {
        var getDoctorByIdQuery = new GetDoctorByIdQuery(doctorId);
        var doctor = await doctorQueryService.Handle(getDoctorByIdQuery);
        if (doctor == null) return NotFound();
        var doctorResource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(doctor);
        return Ok(doctorResource);
    }
}
