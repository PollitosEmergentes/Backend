namespace PeruStar.API.Follower.Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<IEnumerable<Models.Follower>> ListAsync();
        Task<IEnumerable<Models.Follower>> ListByHobbyistIdAsync(long hobbyistId);
        Task<IEnumerable<Models.Follower>> ListByArtistIdAsync(long artistId);
        Task<Models.Follower> FindByHobbyistIdAndArtistId(long hobbyistId, long artistId);
        Task AddAsync(Models.Follower follower);
        void Remove(Models.Follower follower);
        Task AssignFollower(long hobbyistId, long artistId);
        Task UnassignFollower(long hobbyistId, long artistId);

        Task<int> CountFollower(long artistId);
    }
}
