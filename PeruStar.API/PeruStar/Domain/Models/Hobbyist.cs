﻿using PeruStar.API.Event.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Models;

public class Hobbyist : Person
{
    public IList<Interest> Interests { get; set; } = new List<Interest>();
    public IList<FavoriteArtwork> FavoriteArtworks { get; set; } = new List<FavoriteArtwork>();
    public IList<Follower> Followers { get; set; } = new List<Follower>();
    public IList<EventAssistance> Assistance { get; set; } = new List<EventAssistance>();
    public IList<ClaimTicket> ClaimedTickets { get; set; } = new List<ClaimTicket>();
}