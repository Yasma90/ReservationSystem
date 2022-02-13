namespace ReservationSystem.Persistence
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}