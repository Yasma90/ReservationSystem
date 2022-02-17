using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Models;

namespace ReservationSystem.Persistence
{
    public class ReservationSysDbContext : DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactType> ContactType { get; set; }

        public ReservationSysDbContext(DbContextOptions<ReservationSysDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to many relationship: Contact => Reservation
            builder.Entity<Contact>()
                .HasMany(r => r.Reservations)
                .WithOne(c => c.Contact)
                .HasForeignKey(fk => new { fk.ContactId })
                .HasPrincipalKey(pk=>new {pk.Id})
                .OnDelete(DeleteBehavior.Cascade);

            // One to many relationship: Contactype => Contact
            builder.Entity<ContactType>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.ContactType)
                .HasForeignKey(fk => fk.ContactTypeId)
                .HasPrincipalKey(pk => new { pk.Id })
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}