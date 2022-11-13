namespace PeruStar.API.PeruStar.Domain.Models;

public class FavoriteArtwork
{
    public int Id { get; set; }
    public Hobbyist? Hobbyist{ get; set; }
    public long HobbyistId { get; set; }
    public Artwork.Domain.Models.Artwork? Artwork { get; set; }
    public long ArtworkId { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
}