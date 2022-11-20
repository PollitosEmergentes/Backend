using Microsoft.EntityFrameworkCore;
using PeruStar.API.Event.Domain.Models;
using PeruStar.API.Event.Domain.Models.Status;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Shared.Extensions;

namespace PeruStar.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    // Declare DbSet of the entity
    public DbSet<Artist.Domain.Models.Artist> Artists { get; set; } = null!;
    public DbSet<Artwork.Domain.Models.Artwork> Artworks { get; set; } = null!;
    public DbSet<ClaimTicket> ClaimTickets { get; set; } = null!;
    public DbSet<EventAssistance> EventAssistances { get; set; } = null!;
    public DbSet<Event.Domain.Models.Event> Events { get; set; } = null!;
    public DbSet<FavoriteArtwork> FavoriteArtworks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Specialty> Specialties { get; set; } = null!;
    public DbSet<Hobbyist> Hobbyists { get; set; } = null!;

    public DbSet<Follower> Followers { get; set; } = null!;
    public DbSet<Interest> Interests { get; set; } = null!;

    // Structure of the database
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Follower>().ToTable("Followers");
        builder.Entity<Follower>().HasKey(pt =>pt.Id);
        builder.Entity<Follower>().Property(pt => pt.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Follower>().Property(pt => pt.FollowerId).IsRequired();
        builder.Entity<Follower>().Property(pt => pt.ArtistId).IsRequired();

        // Relationships
        builder.Entity<Follower>()
            .HasOne(pt => pt.Hobbyist)
            .WithMany(p => p.Followers)
            .HasForeignKey(pt => pt.HobbyistId);

        builder.Entity<Follower>()
            .HasOne(pt => pt.Artist)
            .WithMany(p => p.Followers)
            .HasForeignKey(pt => pt.ArtistId);


        //  Person entity
        builder.Entity<Person>().ToTable("Persons");
        builder.Entity<Person>().HasKey(p => p.Id);
        builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Person>().Property(p => p.Firstname).IsRequired().HasMaxLength(100);
        builder.Entity<Person>().Property(p => p.Lastname).IsRequired().HasMaxLength(100);
        // Relationships
        
        //  Artist entity
        builder.Entity<Artist.Domain.Models.Artist>().ToTable("Artists");
        builder.Entity<Artist.Domain.Models.Artist>().Property(p => p.BrandName).IsRequired().HasMaxLength(100);
        builder.Entity<Artist.Domain.Models.Artist>().Property(p => p.SpecialtyId).IsRequired();
        builder.Entity<Artist.Domain.Models.Artist>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
        builder.Entity<Artist.Domain.Models.Artist>().Property(p => p.Phrase).IsRequired().HasMaxLength(100);
        builder.Entity<Artist.Domain.Models.Artist>().Property(p => p.SocialMediaLink).HasConversion(
            links => string.Join(',', links.ToArray()),                                         //Como se guarda en la base de datos: Links = "Link1,Link2,Link3"
            links => links.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());         //Come se lee de la base de datos Links=e[0],e[1],e[2]
        // Relationships
        
        builder.Entity<Artist.Domain.Models.Artist>() 
            .HasMany(p => p.Artworks)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);
        
        builder.Entity<Artist.Domain.Models.Artist>() 
            .HasMany(p => p.ClaimTickets)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);

        builder.Entity<Artist.Domain.Models.Artist>()
            .HasMany(p => p.Events)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);

        builder.Entity<Artist.Domain.Models.Artist>()
            .HasOne(p => p.Specialty)
            .WithMany(p => p.Artists)
            .HasForeignKey(p => p.SpecialtyId);
        
        builder.Entity<Artist.Domain.Models.Artist>()
            .HasMany(p => p.Followers)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId);
        
        builder.Entity<Artist.Domain.Models.Artist>()
            .HasMany(p=>p.ClaimTickets)
            .WithOne(p=>p.Artist)
            .HasForeignKey(p=>p.ArtistId);
        
        builder.Entity<Artist.Domain.Models.Artist>()
            .HasMany(p=>p.FavoriteArtworks)
            .WithOne(p=>p.Artist)
            .HasForeignKey(p=>p.ArtistId);
        
        builder.Entity<Artist.Domain.Models.Artist>()
            .HasMany(p=>p.EventAssistances)
            .WithOne(p=>p.Artist)
            .HasForeignKey(p=>p.ArtistId);

        // Artwork entity
        builder.Entity<Artwork.Domain.Models.Artwork>().ToTable("Artworks");
        builder.Entity<Artwork.Domain.Models.Artwork>().HasKey(p => p.ArtworkId);
        builder.Entity<Artwork.Domain.Models.Artwork>().Property(p => p.ArtworkId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Artwork.Domain.Models.Artwork>().Property(p => p.ArtTitle).IsRequired().HasMaxLength(100);
        builder.Entity<Artwork.Domain.Models.Artwork>().Property(p => p.ArtDescription).IsRequired().HasMaxLength(250);
        builder.Entity<Artwork.Domain.Models.Artwork>().Property(p => p.ArtCost);
        builder.Entity<Artwork.Domain.Models.Artwork>().Property(p => p.LinkInfo);
        // Relationships
        
        builder.Entity<Artwork.Domain.Models.Artwork>()
            .HasOne(p => p.Artist)
            .WithMany(p => p.Artworks)
            .HasForeignKey(p => p.ArtistId);
        
        builder.Entity<Artwork.Domain.Models.Artwork>()
            .HasMany(p=>p.FavoriteArtworks)
            .WithOne(p=>p.Artwork)
            .HasForeignKey(p=>p.ArtworkId);
        
        //FavoriteArtwork entity
        builder.Entity<FavoriteArtwork>().ToTable("FavoriteArtworks");
        builder.Entity<FavoriteArtwork>().HasKey(p => p.Id);
        builder.Entity<FavoriteArtwork>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteArtwork>().Property(p => p.HobbyistId).IsRequired();
        builder.Entity<FavoriteArtwork>().Property(p => p.ArtworkId).IsRequired();
        builder.Entity<FavoriteArtwork>().Property(p => p.ArtistId).IsRequired();

        // Relationships
        
        builder.Entity<FavoriteArtwork>()
            .HasOne(pt => pt.Hobbyist)
            .WithMany(p => p.FavoriteArtworks)
            .HasForeignKey(pt => pt.HobbyistId);
        
        builder.Entity<FavoriteArtwork>()
            .HasOne(pt => pt.Artwork)
            .WithMany(p => p.FavoriteArtworks)
            .HasForeignKey(pt => pt.ArtworkId);
        
        builder.Entity<FavoriteArtwork>()
            .HasOne(pt => pt.Artist)
            .WithMany(p => p.FavoriteArtworks)
            .HasForeignKey(pt => pt.ArtistId);

        
        // ClaimTicket entity
        builder.Entity<ClaimTicket>().ToTable("ClaimTickets");
        builder.Entity<ClaimTicket>().HasKey(p => p.ClaimId);
        builder.Entity<ClaimTicket>().Property(p => p.ClaimId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ClaimTicket>().Property(p => p.ClaimSubject).IsRequired().HasMaxLength(40);
        builder.Entity<ClaimTicket>().Property(p => p.ClaimDescription).IsRequired().HasMaxLength(300);
        builder.Entity<ClaimTicket>().Property(p => p.IncidentDate).IsRequired();
        // Relationships
       
        builder.Entity<ClaimTicket>()
            .HasOne(c => c.Hobbyist)
            .WithMany(p => p.ClaimTickets)
            .HasForeignKey(c => c.HobbyistId);

        builder.Entity<ClaimTicket>()
            .HasOne(c => c.Artist)
            .WithMany(p => p.ClaimTickets)
            .HasForeignKey(c => c.ArtistId);
        
        /* 
          builder.Entity<ClaimTicket>()
            .HasOne(c => c.ReportedPerson)
            .WithMany(p => p.ClaimTickets)
            .HasForeignKey(c => c.ReportedPersonId);
        
        builder.Entity<ClaimTicket>()
            .HasOne(c => c.ReportMadeBy)
            .WithMany(p => p.ClaimTickets)
            .HasForeignKey(c => c.ReportMadeById);
        */
       
        
        // EventAssistance entity
        
        builder.Entity<EventAssistance>().ToTable("EventAssistances");
        builder.Entity<EventAssistance>().HasKey(pt =>pt.Id);
        builder.Entity<EventAssistance>().Property(pt => pt.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EventAssistance>().Property(pt => pt.HobbyistId).IsRequired();
        builder.Entity<EventAssistance>().Property(pt => pt.EventId).IsRequired();
        builder.Entity<EventAssistance>().Property(pt => pt.ArtistId).IsRequired();
        
        builder.Entity<EventAssistance>()
            .HasOne(pt => pt.Hobbyist)
            .WithMany(p => p.Assistance)
            .HasForeignKey(pt => pt.HobbyistId);

        builder.Entity<EventAssistance>()
            .HasOne(pt => pt.Event)
            .WithMany(p => p.Assistance)
            .HasForeignKey(pt => pt.EventId);

        builder.Entity<EventAssistance>()
            .HasOne(p => p.Artist)
            .WithMany(p => p.EventAssistances);
            
        
        // Event entity
        builder.Entity<Event.Domain.Models.Event>().ToTable("Events");

        builder.Entity<Event.Domain.Models.Event>().HasKey(p => p.EventId);
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.EventId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.EventTitle).IsRequired().HasMaxLength(100);
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.EventType).IsRequired().HasConversion(
            type => type.ToString(),                                                 
            type => (ETypeOfEvent)Enum.Parse(typeof(ETypeOfEvent), type));  
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.DateStart).IsRequired();
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.DateEnd).IsRequired();
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.EventDescription).IsRequired().HasMaxLength(250);
        builder.Entity<Event.Domain.Models.Event>().Property(p => p.EventAditionalInfo);
        
        // Relationships
        
        builder.Entity<Event.Domain.Models.Event>()
            .HasOne(p => p.Artist)
            .WithMany(p => p.Events)
            .HasForeignKey(p => p.ArtistId);
        
        builder.Entity<Event.Domain.Models.Event>()
            .HasMany(p=>p.Assistance)
            .WithOne(p=>p.Event)
            .HasForeignKey(p=>p.EventId);

            // User entity
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Hobbyist entity

        //Specialty Entity
        builder.Entity<Specialty>().ToTable("Specialties");
        builder.Entity<Specialty>().HasKey(s => s.SpecialtyId);
        builder.Entity<Specialty>().Property(s => s.SpecialtyId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Specialty>().Property(s => s.Name).IsRequired().HasMaxLength(50);
        
        //Relationships
        
        builder.Entity<Specialty>()
            .HasMany(s => s.Artists)
            .WithOne(s => s.Specialty)
            .HasForeignKey(s => s.SpecialtyId);
        
        builder.Entity<Specialty>()
            .HasMany(s=>s.Interests)
            .WithOne(s=>s.Specialty)
            .HasForeignKey(s=>s.SpecialtyId);

        // Interests entity
        builder.Entity<Interest>().ToTable("Interests");
        builder.Entity<Interest>().HasKey(i =>i.Id);
        builder.Entity<Interest>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Interest>().Property(i => i.HobbyistId).IsRequired();
        builder.Entity<Interest>().Property(i => i.SpecialtyId).IsRequired();

        builder.Entity<Interest>()
            .HasOne(i => i.Hobbyist)
            .WithMany(p => p.Interests)
            .HasForeignKey(i => i.HobbyistId);
        
        builder.Entity<Interest>()
            .HasOne(i => i.Specialty)
            .WithMany(p => p.Interests)
            .HasForeignKey(i => i.SpecialtyId);
        
        // Relationships
        
        // Hobbyist entity
        builder.Entity<Hobbyist>().ToTable("Hobbyists");
        builder.Entity<Hobbyist>().Property(h => h.Firstname).IsRequired().HasMaxLength(50);
        builder.Entity<Hobbyist>().Property(h => h.Lastname).IsRequired().HasMaxLength(50);
 
        
        builder.Entity<Hobbyist>()
            .HasMany(h => h.Interests)
            .WithOne(h => h.Hobbyist)
            .HasForeignKey(h => h.HobbyistId);
        
        builder.Entity<Hobbyist>()
            .HasMany(h=>h.FavoriteArtworks)
            .WithOne(h=>h.Hobbyist)
            .HasForeignKey(h=>h.HobbyistId);
        
        builder.Entity<Hobbyist>()
            .HasMany(h=>h.Followers)
            .WithOne(h=>h.Hobbyist)
            .HasForeignKey(h=>h.HobbyistId);
        
        builder.Entity<Hobbyist>()
            .HasMany(h=>h.Assistance)
            .WithOne(h=>h.Hobbyist)
            .HasForeignKey(h=>h.HobbyistId);
        
        builder.Entity<Hobbyist>()
            .HasMany(h=>h.ClaimTickets)
            .WithOne(h=>h.Hobbyist)
            .HasForeignKey(h=>h.HobbyistId);



        builder.UseSnakeCaseNamingConvention();
        
    }
}