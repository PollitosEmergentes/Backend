using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.Event.Resources;

public class SaveEventAssistanceResource
{
    [Required]
    public DateTime AttendanceDay { get; set; }
}