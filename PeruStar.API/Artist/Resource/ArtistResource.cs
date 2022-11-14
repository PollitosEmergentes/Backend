﻿using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artist.Resource;

public class ArtistResource: PersonResource
{
    public string? BrandName { get; set; }
    public string? Description { get; set; }
    public string? Phrase { get; set; }
    public long SpecialtyId { get; set; }
}