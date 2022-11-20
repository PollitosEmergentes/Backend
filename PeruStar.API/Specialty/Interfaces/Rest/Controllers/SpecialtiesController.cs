﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.PeruStar.Resources;
using PeruStar.API.Shared.Extensions;
using PeruStar.API.Specialty.Domain.Services;
using PeruStar.API.Specialty.Interfaces.Internal;
using PeruStar.API.Specialty.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Specialty.Interfaces.Rest.Controllers
{
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;
        private readonly  ISpecialtyFacade _specialtyFacade;
        private readonly IMapper _mapper;

        public SpecialtiesController(ISpecialtyService specialtyService, IMapper mapper, ISpecialtyFacade specialtyFacade)
        {
            _specialtyService = specialtyService;
            _mapper = mapper;
            _specialtyFacade = specialtyFacade;
        }

        /*****************************************************************/
                                /*LIST OF SPECIALTIES*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "List all Specialtys",
         Description = "List of all Specialtys",
         OperationId = "ListAllSpecialtys")]
        [SwaggerResponse(200, "List of Specialtys", typeof(IEnumerable<SpecialtyResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SpecialtyResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<SpecialtyResource>> GetAllAsync()
        {
            var specialty = await _specialtyFacade.ListAsync();
            var resources = _mapper.Map<IEnumerable<Specialty.Domain.Models.Specialty>, IEnumerable<SpecialtyResource>>(specialty);
            return resources;
        }



        /*****************************************************************/
                                /*GET SPECIALTY BY ID*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "Get Specialty by Id",
         Description = "Get Specialty by Id",
         OperationId = "GetSpecialtyById")]
        [SwaggerResponse(200, "Get Specialty by Id", typeof(SpecialtyResource))]

        [HttpGet("{specialtyId}")]
        [ProducesResponseType(typeof(SpecialtyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(long specialtyId)
        {
            var result = await _specialtyFacade.GetByIdAsync(specialtyId);
            if (!result.Success)
                return BadRequest(result.Message);
            var specialtyResource = _mapper.Map<Specialty.Domain.Models.Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);
        }




        /*****************************************************************/
                                   /*SAVE SPECIALTY*/
        /*****************************************************************/

        [SwaggerOperation(
          Summary = "Save Specialty",
          Description = "Save Specialty",
          OperationId = "SaveSpecialty")]
        [SwaggerResponse(200, "Save Specialty", typeof(SpecialtyResource))]

        [HttpPost]
        [ProducesResponseType(typeof(SpecialtyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSpecialtyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var specialty = _mapper.Map<SaveSpecialtyResource, Specialty.Domain.Models.Specialty>(resource);
            var result = await _specialtyService.SaveAsync(specialty);

            if (!result.Success)
                return BadRequest(result.Message);

            var specialtyResource = _mapper.Map<Specialty.Domain.Models.Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);

        }



        /*****************************************************************/
                                /*UPDATE SPECIALTY*/
        /*****************************************************************/

        [SwaggerOperation(
        Summary = "Update Specialty",
        Description = "Update Specialty",
        OperationId = "UpdateSpecialty")]
        [SwaggerResponse(200, "Update Specialty", typeof(SpecialtyResource))]


        [HttpPut("{specialtyId}")]
        [ProducesResponseType(typeof(SpecialtyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long specialtyId, [FromBody] SaveSpecialtyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var specialty = _mapper.Map<SaveSpecialtyResource, Specialty.Domain.Models.Specialty>(resource);
            var result = await _specialtyService.UpdateAsync(specialtyId, specialty);

            if (!result.Success)
                return BadRequest(result.Message);

            var specialtyResource = _mapper.Map<Specialty.Domain.Models.Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);
        }



        /*****************************************************************/
                                /*DELETE SPECIALTY*/
        /*****************************************************************/

        [SwaggerOperation(
           Summary = "Delete Specialty",
           Description = "Delete Specialty",
           OperationId = "DeleteSpecialty")]
        [SwaggerResponse(200, "Delete Specialty", typeof(SpecialtyResource))]

        [HttpDelete("{specialtyId}")]
        [ProducesResponseType(typeof(SpecialtyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long specialtyId)
        {
            var result = await _specialtyService.DeleteAsync(specialtyId);
            if (!result.Success)
                return BadRequest(result.Message);
            var specialtyResource = _mapper.Map<Specialty.Domain.Models.Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);
        }
    }
}
