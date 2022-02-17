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
            if (!context.Contact.Any() || !context.ContactType.Any())
            {
                var types = new List<ContactType>
                {
                    new ContactType{Id = Guid.NewGuid(), Name = "Standard"},
                    new ContactType{Id = Guid.NewGuid(), Name = "Premium"},
                    new ContactType{Id = Guid.NewGuid(), Name = "Plus"},
                    new ContactType{Id = Guid.NewGuid(), Name = "VIP"}
                };
                var contacts = new List<Contact>{
                    new Contact
                    {
                        Id = Guid.NewGuid(),
                        Name = "Luna Gold",
                        BirthDate = DateTime.Now.AddYears(-19).AddDays(24),
                        PhoneNumber = "+53 5480341",
                        ContactTypeId = types[0].Id
                    },
                    new Contact
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sophie Pattsom",
                        BirthDate = DateTime.Now.AddYears(-29),
                        PhoneNumber = "+1 870 257 455",
                        ContactTypeId = types[2].Id
                    },
                    new Contact
                    {
                        Id = Guid.NewGuid(),
                        Name = "Mathew Black",
                        BirthDate = DateTime.Now.AddYears(-32),
                        PhoneNumber = "+34 879 8578",
                        ContactTypeId = types[3].Id
                    },
                    new Contact
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jason Wall",
                        BirthDate = DateTime.Now.AddYears(-24),
                        PhoneNumber = "+27 7859 3576",
                        ContactTypeId = types[1].Id
                    }
                };
                var reservations = new List<Reservation>{
                    new Reservation
                    {
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Come with us and really you know what is the paraise.",
                        Favorite = false,
                        Ranking = 1,
                        ContactId = contacts[1].Id
                    },
                    new Reservation 
                    {
                        Date = DateTime.Now.AddYears(-1).AddDays(-49),
                        Description = "If you really want to travel inside you, come with us and will see.",
                        Favorite = true,
                        Ranking = 4,
                        ContactId = contacts[3].Id
                    },
                    new Reservation
                    {
                        Date = DateTime.Now.AddDays(-18),
                        Description = "The sea as perfect than you.",
                        Favorite = true,
                        Ranking = 3,
                        ContactId = contacts[0].Id
                    }
                };

                context.ContactType.AddRange(types);
                context.Contact.AddRangeAsync(contacts);
                context.Reservation.AddRange(reservations);
            }

            context.SaveChanges();
        }
    }
}
