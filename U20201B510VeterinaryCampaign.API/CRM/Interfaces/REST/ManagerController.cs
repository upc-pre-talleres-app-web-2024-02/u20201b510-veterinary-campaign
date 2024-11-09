using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Queries;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Services;
using U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Resources;
using U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Transform;

namespace U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Manager Endpoints")]
public class ManagerController(IManagerQueryService managerQueryService, IManagerCommandService managerCommandService) : ControllerBase
{

    [HttpGet("manager/{id}")]
    [SwaggerOperation(
        Summary = "Get a manager by id",
        Description = "Get a manager by id",
        OperationId = "GetManagerById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The Manager was found", typeof(ManagerResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The Manager was not found")]
    public async Task<IActionResult> GetManager(int id)
    {
        var manager = await managerQueryService.Handle(new GetManagerByIdQuery(id));
        
        if (manager is null) return NotFound(new { Title = "Not Found Manager", Message = $"Manager with id {id} was not found." });
        
        var managerResource = ManagerResourceFromEntityAssembler.ToResourceFromEntity(manager);

        return Ok(managerResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new Manager",
        Description = "Create a new Manager",
        OperationId = "CreateManager"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The Manager was created", typeof(ManagerResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateManager([FromBody] CreateManagerResource resource)
    {
        var createManagerCommand = CreateManagerCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var manager = await managerCommandService.Handle(createManagerCommand);
        
        if (manager is null) return BadRequest(new { Title = "Bad Request", Message = "The request is invalid." });

        var managerResource = ManagerResourceFromEntityAssembler.ToResourceFromEntity(manager);
        
        return CreatedAtAction(nameof(GetManager), new {id = managerResource.Id}, managerResource);
    }

}