using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Event.Domain.Services.Communication;

public class EventResponse : BaseResponse<Models.Event>
{
    public EventResponse(Models.Event resource) : base(resource)
    {
    }

    public EventResponse(string message) : base(message)
    {
    }
}