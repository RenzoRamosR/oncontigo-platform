using Microsoft.AspNetCore.Mvc;
using oncontigo_platform.IAM.Domain.Services;
using oncontigo_platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using oncontigo_platform.IAM.Interfaces.REST.Resources;
using oncontigo_platform.IAM.Interfaces.REST.Transform;
using System.Net.Mime;

namespace oncontigo_platform.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new { message = "User created successfully" });
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var authenticatedUserResource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }
}