using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Hobbyist.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Domain.Services;

public interface IClaimTicketService
{
    Task<IEnumerable<ClaimTicket>> ListAsync();
    Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long personId);
    Task<IEnumerable<ClaimTicket>> ListAsyncByReportedPersonId(long personId);
    Task<ClaimTicketResponse> GetByIdAndPersonIdAsync(long personId, long claimTicketId);
    Task<ClaimTicketResponse> SaveAsync(long personId, ClaimTicket claimTicket);
    Task<ClaimTicketResponse> UpdateAsync(long personId, long claimTicketId, ClaimTicket claimTicket);
    Task<ClaimTicketResponse> DeleteAsync(long personId, long claimTicketId);
}