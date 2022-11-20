using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.Specialty.Resources;

    public class SaveSpecialtyResource
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }

