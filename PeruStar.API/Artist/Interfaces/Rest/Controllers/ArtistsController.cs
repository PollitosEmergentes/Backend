using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.Artist.Domain.Services;
using PeruStar.API.Artist.Interfaces.Internal;
using PeruStar.API.Artist.Resource;
using PeruStar.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Artist.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creat, Read, Update, Delete and Artists")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;
    private readonly IArtistFacade _artistFacade;
    private readonly IMapper _mapper;

    public ArtistsController(IArtistService artistService, IMapper mapper, IArtistFacade artistFacade)
    {
        _artistService = artistService;
        _mapper = mapper;
        _artistFacade = artistFacade;
    }


    /*****************************************************************/
    /*LIST OF ARTISTS*/
    /*****************************************************************/

    [SwaggerOperation(
        Summary = "List all Artists",
        Description = "List of all Artists",
        OperationId = "ListAllArtists")]
    [SwaggerResponse(200, "List of Artists", typeof(IEnumerable<ArtistResource>))]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ArtistResource>), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IEnumerable<ArtistResource>> GetAllAsync()
    {
        var artist = await _artistFacade.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Artist>, IEnumerable<ArtistResource>>(artist);
        return resources;
    }


    /*****************************************************************/
    /*GET ARTIST BY ID*/
    /*****************************************************************/

    [SwaggerOperation(
        Summary = "Get Artist by Id",
        Description = "Get Artist by Id",
        OperationId = "GerArtistById")]
    [SwaggerResponse(200, "Get Artist by Id", typeof(ArtistResource))]
    [HttpGet("{artistId}")]
    [ProducesResponseType(typeof(ArtistResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> GetByIdAsync(long artistId)
    {
        var result = await _artistFacade.GetByIdAsync(artistId);
        if (!result.Success)
            return BadRequest(result.Message);
        var artistResource = _mapper.Map<Domain.Models.Artist, ArtistResource>(result.Resource);
        return Ok(artistResource);
    }


    /*****************************************************************/
    /*SAVE ARTIST*/
    /*****************************************************************/

    [SwaggerOperation(
        Summary = "Save Artist",
        Description = "Save Artist",
        OperationId = "SaveArtist")]
    [SwaggerResponse(200, "Save Artist", typeof(ArtistResource))]
    [HttpPost]
    [ProducesResponseType(typeof(ArtistResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> PostAsync([FromBody] SaveArtistResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var artist = _mapper.Map<SaveArtistResource, Domain.Models.Artist>(resource);
        var result = await _artistService.SaveAsync(artist);

        if (!result.Success)
            return BadRequest(result.Message);

        var artistResource = _mapper.Map<Domain.Models.Artist, ArtistResource>(result.Resource);
        return Ok(artistResource);
    }


    /*****************************************************************/
    /*UPDATE ARTIST*/
    /*****************************************************************/

    [SwaggerOperation(
        Summary = "Update Artist",
        Description = "Update Artist",
        OperationId = "UpdateArtist")]
    [SwaggerResponse(200, "Update Artist", typeof(ArtistResource))]
    [HttpPut("{artistId}")]
    [ProducesResponseType(typeof(ArtistResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> PutAsync(long artistId, [FromBody] SaveArtistResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var artist = _mapper.Map<SaveArtistResource, Domain.Models.Artist>(resource);
        var result = await _artistService.UpdateAsync(artistId, artist);

        if (!result.Success)
            return BadRequest(result.Message);

        var artistResource = _mapper.Map<Domain.Models.Artist, ArtistResource>(result.Resource);
        return Ok(artistResource);
    }


    /*****************************************************************/
    /*DELETE ARTIST*/
    /*****************************************************************/

    [SwaggerOperation(
        Summary = "Delete Artist",
        Description = "Delete Artist",
        OperationId = "DeleteArtist")]
    [SwaggerResponse(200, "Delete Artist", typeof(ArtistResource))]
    [HttpDelete("{artistId}")]
    [ProducesResponseType(typeof(ArtistResource), 200)]
    [ProducesResponseType(typeof(BadRequestResult), 404)]
    public async Task<IActionResult> DeleteAsync(long artistId)
    {
        var result = await _artistService.DeleteAsync(artistId);
        if (!result.Success)
            return BadRequest(result.Message);
        var artistResource = _mapper.Map<Domain.Models.Artist, ArtistResource>(result.Resource);
        return Ok(artistResource);
    }
}