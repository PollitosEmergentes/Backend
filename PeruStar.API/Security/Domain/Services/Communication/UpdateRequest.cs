﻿namespace PeruStar.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
}