namespace PeruStar.API.PeruStar.Domain.Models;

public class FavoriteArtwork
{
    public int Id { get; set; }
    public Hobbyist? Hobbyist{ get; set; }
    public long HobbyistId { get; set; }
    public Artwork? Artwork { get; set; }
    public long ArtworkId { get; set; }
    public Artist? Artist { get; set; }
    public long ArtistId { get; set; }
}