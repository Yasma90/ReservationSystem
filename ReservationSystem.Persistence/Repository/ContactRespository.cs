using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.Repository.Interface;
using ReservationSystem.Persistence;

namespace ReservationSystem.Persistence.Repository
{
    public class ContactRespository: GenericRepository<Contact>, IContactRespository
    {
        public ContactRespository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
