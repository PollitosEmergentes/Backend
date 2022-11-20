using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.Artist.Resource;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Event.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/hobbyists/{hobbyistId}/specialties")]
[Produces("application/json")]
[SwaggerTag("Creat, Read, Update, Delete a Interest")]
 public class InterestsController : ControllerBase
 {
        private readonly ISpecialtyService _specialtyService;
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;

        public InterestsController(ISpecialtyService specialtyService, IInterestService interestService, IMapper mapper)
        {
            _specialtyService = specialtyService;
            _interestService = interestService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "Assign Interest",
        Description = "Assign Interest",
        OperationId = "AssignInterest")]
        [SwaggerResponse(200, "Assign Interest", typeof(SpecialtyResource))]

        [HttpPost("{specialtyId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> AssignHobbyistSpecialty(int hobbyistId, int specialtyId)
        {
            var result = await _interestService.AssingInterestAsync(hobbyistId, specialtyId);          

            if (!result.Success)
                return BadRequest(result.Message);

            var specialtyResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource.Specialty!);
            return Ok(specialtyResource);

        }


        [SwaggerOperation(
        Summary = "Unassign Interest",
        Description = "Unassign Interest",
        OperationId = "UnassignInterest")]
        [SwaggerResponse(200, "Unassign Interest", typeof(SpecialtyResource))]

        [HttpDelete("{specialtyId}")]
        [ProducesResponseType(typeof(ArtistResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> UnassignHobbyistSpecialty(int hobbyistId, int specialtyId)
        {
            var result = await _interestService.UnassignInterestAsync(hobbyistId, specialtyId);

            if (!result.Success)
                return BadRequest(result.Message);

            var specialtyResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource.Specialty!);
            return Ok(specialtyResource);

        }

    }