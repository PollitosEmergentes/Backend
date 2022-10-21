using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.PeruStar.Controllers;


[Route("/api/artists/{artistId}/followers")]
[Produces("application/json")]
[ApiController]
public class FollowersController: ControllerBase
    {
        private readonly IFollowerService _followerService;
        private readonly IMapper _mapper;

        public FollowersController(IFollowerService followerService, IMapper mapper)
        {
            _followerService = followerService;
            _mapper = mapper;
        }



        /*****************************************************************/
                                 /*ASSIGN FOLLOWER*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Assign Follower",
           Description = "Assign Follower",
           OperationId = "AssignFollower")]
        [SwaggerResponse(200, "Artist Assign Follower", typeof(ArtistResource))]

        [HttpPost("{hobbyistId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AssignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.AssignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist!);
            return Ok(artistResource);
        }



        /*****************************************************************/
                                /*UNASSIGN FOLLOWER*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Unassign Follower",
           Description = "Unassign Follower",
           OperationId = "UnassignFollower")]
        [SwaggerResponse(200, "Artist Unassign Follower", typeof(ArtistResource))]

        [HttpDelete("{hobbyistId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> UnassignFollower(int hobbyistId, int artistId)
        {
            var result = await _followerService.UnassignFollowerAsync(hobbyistId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var artistResource = _mapper.Map<Artist, ArtistResource>(result.Resource.Artist!);
            return Ok(artistResource);
        }

        


        /*****************************************************************/
                          /*COUNT OF ARTISTS' FOLLOWERS*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Count Artists' Followers",
           Description = "Count Artists' Followers",
           OperationId = "CountFollowers")]
        [SwaggerResponse(200, "Count Followers", typeof(int))]

        [HttpGet("count")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> CountFollowers(long artistId)
        {
            var count = await _followerService.CountFollowers(artistId);
            return Ok(count);
        }
    }