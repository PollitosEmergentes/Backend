using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Domain.Services.Communication;

public class ClaimTicketResponse : BaseResponse<ClaimTicket>
{
    public ClaimTicketResponse(ClaimTicket resource) : base(resource)
    {
    }

    public ClaimTicketResponse(string message) : base(message)
    {
    }
}