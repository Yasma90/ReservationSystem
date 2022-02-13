using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ReservationSysDbContext>();
            context.Database.Migrate();
        }

        public void SeedData()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ReservationSysDbContext>();
            if (!context.Contact.Any())
            {
                var types = new List<ContactType>
                {
                    new ContactType{Id = Guid.NewGuid(), Name = "Standard"},
                    new ContactType{Id = Guid.NewGuid(), Name = "Premium"},
                    new ContactType{Id = Guid.NewGuid(), Name = "Plus"},
                    new ContactType{Id = Guid.NewGuid(), Name = "VIP"}
                };
                var contact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Luna Gold",
                    BirthDate = DateTime.Now.AddYears(-19).AddDays(24),
                    PhoneNumber = "+53 54803401",
                    ContactTypeId = types[0].Id
                };
                var reservation = new Reservation
                {
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Come with us and really you know what is the paraise",
                    Favorite = true,
                    Ranking = 1,
                    ContactId = contact.Id
                };

                context.ContactType.AddRange(types);
                context.Contact.AddRange(contact);
                context.Reservation.Add(reservation);
            }

            context.SaveChanges();
        }
    }
}
