using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.Artwork.Domain.Services;
using PeruStar.API.Artwork.Interfaces.Internal;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Event.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/hobbyists/{hobbyistId}/artworks")]
[Produces("application/json")]
[SwaggerTag("Favorite Artworks of a Hobbyist")]
public class FavoriteArtworksController: ControllerBase
{
    private readonly IFavoriteArtworkService _favoriteArtworkService;
        private readonly IArtworkService _artworkService;
        private readonly IArtworkFacade _artworkFacade;
        private readonly IMapper _mapper;

        public FavoriteArtworksController(IFavoriteArtworkService favoriteArtworkService, IMapper mapper, IArtworkService artworkService, IArtworkFacade artworkFacade)
        {
            _favoriteArtworkService = favoriteArtworkService;
            _mapper = mapper;
            _artworkService = artworkService;
            _artworkFacade = artworkFacade;
        }



        /*****************************************************************/
                   /*LIST OF ALL FAVORITE ARTWORKS BY HOBBYIST ID*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Get All Favorite Artworks By Hobbyist Id",
           Description = "Get All Favorite Artworks By Hobbyist Id",
           OperationId = "GetAllFavoriteArtworksByHobbyistId")]
        [SwaggerResponse(200, "Get All Favorite Artworks By Hobbyist Id", typeof(IEnumerable<ArtworkResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtworkResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<ArtworkResource>> GetAllByHobbyistIdAsync(long hobbyistId)
        {
            var artworks = await _artworkFacade.ListByHobbyistAsync(hobbyistId);
            var resources = _mapper.Map<IEnumerable<Artwork.Domain.Models.Artwork>, IEnumerable<ArtworkResource>>(artworks);
            return resources;
        }



        /*****************************************************************/
                             /*ASSIGN FAVORITE ARTWORK*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Assign Favorite Artwork",
           Description = "Assign Favorite Artwork",
           OperationId = "AssignFavoriteArtwork")]
        [SwaggerResponse(200, "Favorite Artwork Assigned", typeof(ArtworkResource))]

        [HttpPost("{artworkId}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AssignFavoriteArtwork(long hobbyistId, long artworkId)
        {
            var result = await _favoriteArtworkService.AssignFavoriteArtworkAsync(hobbyistId, artworkId);
            if (!result.Success)
                return BadRequest(result.Message);
            var artworkResource = _mapper.Map<Artwork.Domain.Models.Artwork, ArtworkResource>(result.Resource.Artwork!);
            return Ok(artworkResource);
        }



        /*****************************************************************/
                            /*UNASSIGN FAVORITE ARTWORK*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Unassign Favorite Artwork",
           Description = "Unassign Favorite Artwork",
           OperationId = "UnassignFavoriteArtwork")]
        [SwaggerResponse(200, "Favorite Artwork Unassigned", typeof(ArtworkResource))]

        [HttpDelete("{artworkId}")]
        [ProducesResponseType(typeof(ArtworkResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> UnassignFavoriteArtwork(long hobbyistId, long artworkId)
        {
            var result = await _favoriteArtworkService.UnassignFavoriteArtworkAsync(hobbyistId, artworkId);
            if (!result.Success)
                return BadRequest(result.Message);
            var favoriteArtworkResource = _mapper.Map<Artwork.Domain.Models.Artwork, ArtworkResource>(result.Resource.Artwork!);
            return Ok(favoriteArtworkResource);
        }
}