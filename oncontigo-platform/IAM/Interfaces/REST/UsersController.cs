﻿using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.IAM.Domain.Model.Queries;
using oncontigo_platform.IAM.Domain.Services;
using oncontigo_platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using oncontigo_platform.IAM.Interfaces.REST.Transform;
using System.Net.Mime;

namespace oncontigo_platform.IAM.Interfaces.REST;
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
}
