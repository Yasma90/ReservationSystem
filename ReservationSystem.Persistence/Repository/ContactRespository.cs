using ReservationSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Persistence.Repository
{
    public class ContactRespository: GenericRepository<Contact>, IContactRespository
    {
        public ContactRespository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
