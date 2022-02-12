using ReservationSystem.Domain.Models;
using ReservationSystem.Persistence.Repository.Interfaces;

namespace ReservationSystem.Persistence.Repository
{
    public class ContactRespository: GenericRepository<Contact>, IContactRespository
    {
        public ContactRespository(ReservationSysDbContext context) : base(context)
        {
        }
    }
}
