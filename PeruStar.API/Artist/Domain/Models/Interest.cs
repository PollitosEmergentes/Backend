namespace PeruStar.API.Artist.Domain.Models;

public class Interest
{
    public long Id { get; set; }
    public long HobbyistId { get; set; }
    public Hobbyist.Domain.Models.Hobbyist? Hobbyist { get; set; }
    public long SpecialtyId { get; set; }
    public Specialty.Domain.Models.Specialty? Specialty { get; set; }
}