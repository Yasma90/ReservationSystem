using System;
using System.Threading.Tasks;
using ReservationSystem.Persistence.Repository.Interfaces;

namespace ReservationSystem.Persistence.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRespository ContactRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        IContactTypeRepository ContactTypeRepository { get; set; }

        Task<int> SaveChangesAsync();
    }
}