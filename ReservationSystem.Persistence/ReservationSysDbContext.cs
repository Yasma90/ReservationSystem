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
            builder.Entity<Reservation>()
                .HasOne(r => r.Contact)
                .WithMany()
                .HasForeignKey(fk => fk.ContactId);

            builder.Entity<Contact>()
                .HasOne(c => c.ContactType)
                .WithMany()
                .HasForeignKey(fk => fk.ContactTypeId);

            builder.Entity<ContactType>()             
                .HasMany(c => c.Contacts)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);

        }

    }
}