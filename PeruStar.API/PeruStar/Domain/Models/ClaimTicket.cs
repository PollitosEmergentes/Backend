using System.ComponentModel.DataAnnotations.Schema;

namespace PeruStar.API.PeruStar.Domain.Models;

public class ClaimTicket
{
    public long ClaimId { get; set; }
    public string? ClaimSubject { get; set; }
    public string? ClaimDescription { get; set; }
    public DateTime IncidentDate { get; set; }
    public long HobbyistId { get; set; }
    public Hobbyist? Hobbyist { get; set; }
    [NotMapped]
    public Person? ReportedPerson { get; set; }
    [NotMapped]
    public Person? ReportMadeBy { get; set; }
    public long ReportedPersonId { get; set; }
    public long ReportMadeById { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
}