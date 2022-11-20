using PeruStar.API.Follower.Domain.Services.Communication;

namespace PeruStar.API.Follower.Domain.Services
{
    public interface IFollowerService
    {
        Task<IEnumerable<Models.Follower>> ListAsync();
        Task<IEnumerable<Models.Follower>> ListByHobbyistIdAsync(long id); 

        Task<IEnumerable<Models.Follower>> ListByArtistIdAsync(long id);

        Task<int> CountFollowers(long artistId);

        Task<FollowerResponse> AssignFollowerAsync(long hobbyistId, long artistId);
        Task<FollowerResponse> UnassignFollowerAsync(long hobbyistId, long artistId);
    }
}
