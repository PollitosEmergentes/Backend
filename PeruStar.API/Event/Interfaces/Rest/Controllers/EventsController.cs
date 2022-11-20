﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.Event.Domain.Services;
using PeruStar.API.Event.Interfaces.Internal;
using PeruStar.API.Event.Resources;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Resources;
using PeruStar.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Event.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/artists/{artistId}/events")]
[Produces("application/json")]
[SwaggerTag("Create, read, update, and delete events for an artist.")]
public class EventsController : ControllerBase
{
        private readonly IEventService _eventService;
        private readonly IEventFacade _eventFacade;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper, IEventFacade eventFacade)
        {
            _eventService = eventService;
            _mapper = mapper;
            _eventFacade = eventFacade;
        }



        /*****************************************************************/
                          /*LIST OF EVENTS BY ARTIST ID*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "List Events By Artist Id",
         Description = "List Events By Artist Id",
         OperationId = "ListEventsByArtistId")]
        [SwaggerResponse(200, "List of Events By Artist Id", typeof(IEnumerable<EventResource>))]

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<EventResource>> GetAllByArtistIdAsync(long artistId)
        {
            var events = await _eventFacade.ListAsyncByArtistId(artistId);
            var resources = _mapper.Map<IEnumerable<Domain.Models.Event>, IEnumerable<EventResource>>(events);
            return resources;
        }



        /*****************************************************************/
                                /*GET EVENT BY ID*/
        /*****************************************************************/
        
        [SwaggerOperation(
         Summary = "Get Event By Id",
         Description = "Get Event By Id",
         OperationId = "GetEventById")]
        [SwaggerResponse(200, "Get Event By Id", typeof(EventResource))]

        [HttpGet("{eventId}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(long eventId, long artistId)
        {
            var result = await _eventFacade.GetByIdAndArtistIdAsync(eventId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Domain.Models.Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }



        /*****************************************************************/
                                    /*SAVE EVENT*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "Save Event",
         Description = "Save Event",
         OperationId = "SaveEvent")]
        [SwaggerResponse(200, "Save Event", typeof(EventResource))]

        [HttpPost]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(long artistId, [FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var _event = _mapper.Map<SaveEventResource, Domain.Models.Event>(resource);
            var result = await _eventService.SaveAsync(artistId, _event);

            if (!result.Success)
                return BadRequest(result.Message);
            var eventResource = _mapper.Map<Domain.Models.Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }



        /*****************************************************************/
                                /*UPDATE EVENT*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "Update Event",
         Description = "Update Event",
         OperationId = "UpdateEvent")]
        [SwaggerResponse(200, "Update Event", typeof(EventResource))]

        [HttpPut("{eventId}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long eventId, long artistId, [FromBody] SaveEventResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var _event = _mapper.Map<SaveEventResource, Domain.Models.Event>(resource);
            var result = await _eventService.UpdateAsync(eventId, artistId, _event);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Domain.Models.Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }



        /*****************************************************************/
                                /*DELETE EVENT*/
        /*****************************************************************/

        [SwaggerOperation(
         Summary = "Delete Event",
         Description = "Delete Event",
         OperationId = "DeleteEvent")]
        [SwaggerResponse(200, "Delete Event", typeof(EventResource))]

        [HttpDelete("{eventId}")]
        [ProducesResponseType(typeof(EventResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long eventId, long artistId)
        {
            var result = await _eventService.DeleteAsync(eventId, artistId);
            if (!result.Success)
                return BadRequest(result.Message);

            var eventResource = _mapper.Map<Domain.Models.Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }
}