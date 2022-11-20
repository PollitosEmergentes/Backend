using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.Follower.Resources
{
    public class SaveFollowerResource
    {
        [Required]
        public long ArtistId { get; set; }
    }
}
