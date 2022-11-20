using PeruStar.API.Event.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Event.Domain.Services.Communication;

public class EventAssistanceResponse : BaseResponse<EventAssistance>
{
    public EventAssistanceResponse(EventAssistance resource) : base(resource)
    {
    }

    public EventAssistanceResponse(string message) : base(message)
    {
    }
}