using ReservationSystem.Persistence.Repository;
using System;
using System.Threading.Tasks;

namespace ReservationSystem.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ContactRespository ContactRespository { get; set; }
        ReservationRepository ReservationRespository { get; set; }
        Task<int> SaveChangesAsync();
    }
}