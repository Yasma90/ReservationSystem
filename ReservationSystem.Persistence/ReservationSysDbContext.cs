﻿using System;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Models;

namespace ReservationSystem.Persistence
{
    public class ReservationSysDbContext : DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public ReservationSysDbContext(DbContextOptions<ReservationSysDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to many relationship
            builder.Entity<Contact>()
                .HasMany(r => r.Reservations)
                .WithOne(c => c.Contact)
                .HasForeignKey(fk => fk.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}