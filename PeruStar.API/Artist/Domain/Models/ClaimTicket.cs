using System.ComponentModel.DataAnnotations.Schema;
using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Artist.Domain.Models;

public class ClaimTicket
{
    public long ClaimId { get; set; }
    public string? ClaimSubject { get; set; }
    public string? ClaimDescription { get; set; }
    public DateTime IncidentDate { get; set; }
    public long HobbyistId { get; set; }
    public Hobbyist.Domain.Models.Hobbyist? Hobbyist { get; set; }
    [NotMapped]
    public Person? ReportedPerson { get; set; }
    [NotMapped]
    public Person? ReportMadeBy { get; set; }
    public long ReportedPersonId { get; set; }
    public long ReportMadeById { get; set; }
    public API.Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
}