﻿using System.Net.Mime;
using oncontigo_platform.Profiles.Domain.Model.Queries;
using oncontigo_platform.Profiles.Domain.Services;
using oncontigo_platform.Profiles.Interfaces.REST.Resources;
using oncontigo_platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace oncontigo_platform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { profileId = profileResource.Id }, profileResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }

    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

}
