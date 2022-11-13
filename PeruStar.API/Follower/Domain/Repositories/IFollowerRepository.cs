using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<IEnumerable<Follower>> ListAsync();
        Task<IEnumerable<Follower>> ListByHobbyistIdAsync(long hobbyistId);
        Task<IEnumerable<Follower>> ListByArtistIdAsync(long artistId);
        Task<Follower> FindByHobbyistIdAndArtistId(long hobbyistId, long artistId);
        Task AddAsync(Follower follower);
        void Remove(Follower follower);
        Task AssignFollower(long hobbyistId, long artistId);
        Task UnassignFollower(long hobbyistId, long artistId);

        Task<int> CountFollower(long artistId);
    }
}
