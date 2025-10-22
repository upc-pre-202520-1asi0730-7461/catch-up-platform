using System.Net.Mime;
using CatchUpPlatform.API.News.Domain.Model.Queries;
using CatchUpPlatform.API.News.Domain.Services;
using CatchUpPlatform.API.News.Interfaces.REST.Resources;
using CatchUpPlatform.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CatchUpPlatform.API.News.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources")]
public class FavoriteSourcesController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService)
: ControllerBase
{
    
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get Favorite Source by Id",
        Description = "Retrieves a favorite source by its unique identifier.",
        OperationId = "GetFavoriteSourceById")]
    [SwaggerResponse(200, "Favorite source retrieved successfully.", typeof(FavoriteSourceResource))]
    public async Task<IActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Favorite Source",
        Description = "Creates a new favorite source.",
        OperationId = "CreateFavoriteSource")]
    [SwaggerResponse(201, "Favorite source created successfully.", typeof(FavoriteSourceResource))]
    [SwaggerResponse(400, "Invalid input data.")]
    public async Task<IActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        if (result is null) return BadRequest();
        var favoriteSourceResource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = favoriteSourceResource.Id }, favoriteSourceResource);
    }
    
}